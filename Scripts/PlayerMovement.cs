using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
        public static event Action OnPlayerShootSound;

        Rigidbody2D rb;
        Damageable damageable;

        [Header("Player Values")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float fireDelay;
        [SerializeField] private float shootCoolDownTime;

        [Header("GameObject Prefabs")]
        [SerializeField] private GameObject pinkBulletPrefab;

        [Header("Bullet Locations")]
        [SerializeField] private Transform bulletLocationOne;
        [SerializeField] private Transform bulletLocationTwo;

        [Header("Player Child Objects")]
        [SerializeField] private GameObject exhaustOne;
        [SerializeField] private GameObject exhaustTwo;

        Vector2 moveInput;

        private bool canMove = true;

        private void Start()
        {
                // Get component on start
                rb = GetComponent<Rigidbody2D>();
                damageable = GetComponent<Damageable>();

                // Set exhaust objects to false on start since not moving
                exhaustOne.SetActive(false);
                exhaustTwo.SetActive(false);
        }

        private void Update()
        {
                // Countdown fireDelay by time
                fireDelay -= Time.deltaTime;

                // If input value does not equal (0, 0) then object is moving and exhaust needs to be active
                if (moveInput != Vector2.zero)
                {
                        exhaustOne.SetActive(true);
                        exhaustTwo.SetActive(true);
                }
                else
                {
                        exhaustOne.SetActive(false);
                        exhaustTwo.SetActive(false);
                }
        }

        private void FixedUpdate()
        {
                // Make player always face mouse position
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = (mousePos - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation , 1f);

                // If we input is allowed, then move rigidbody in FixedUpdate since dealing with physics
                if (canMove)
                {
                        rb.AddRelativeForce(moveInput * moveSpeed);
                }
                else
                {
                        rb.velocity = Vector3.zero;
                }
        }

        public void MovePlayer(InputAction.CallbackContext ctx)
        {
                // Read value of input manager and place in Vector2
                moveInput = ctx.ReadValue<Vector2>();
        }

        public void ShootBullet(InputAction.CallbackContext ctx)
        {
                // If cooldown is zero then we can shoot, reset cooldown timer
                if (fireDelay <= 0)
                {
                        OnPlayerShootSound?.Invoke();
                        fireDelay = shootCoolDownTime;
                        Instantiate(pinkBulletPrefab , bulletLocationOne.position , this.transform.rotation);
                        Instantiate(pinkBulletPrefab , bulletLocationTwo.position , this.transform.rotation);
                }
        }
}
