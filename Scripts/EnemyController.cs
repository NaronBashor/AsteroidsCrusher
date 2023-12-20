using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
        public static event Action OnGiveUFOPoints;
        public static event Action OnGiveMothershipPoints;

        Rigidbody2D rb;
        Damageable damageable;

        [SerializeField] private float playerDistance;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float shootDelay;
        [SerializeField] private float shootTimer;
        [SerializeField] private float bulletAmount;
        [SerializeField] private float numberOfBulletsToShoot;
        [SerializeField] private float enemyBulletSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private bool isMothership = false;
        [SerializeField] private GameObject enemyBulletPrefab;

        GameObject player;

        private bool canFire = false;
        private bool foundPlayer = false;
        private bool shootBullets = false;
        private bool addPoints = false;

        private void Start()
        {
                // Get components on start
                rb = GetComponent<Rigidbody2D>();
                damageable = GetComponent<Damageable>();

                // Assign player to game object for reference
                player = GameObject.Find("Player");
        }

        private void Update()
        {
                // Rotate UFO every frame
                this.transform.Rotate(0f , 0f , rotateSpeed * Time.deltaTime);

                // Check if can shoot, and if it is shooting already, and that player is not null to execute code without errors
                if (canFire && shootBullets && player != null)
                {
                        // Begin shooting delay
                        StartCoroutine(RepeatMethodCoroutine());
                }

                // Count down timer to shoot
                shootTimer -= Time.deltaTime;

                // When timer is zero execute code
                if (shootTimer <= 0)
                {
                        shootTimer = shootDelay;
                        shootBullets = true;
                }
                else if (shootTimer > 0)
                {
                        shootBullets = false;
                }

                // Check if player is not null to avoid errors
                if (player != null)
                {
                        // Check distance between enemy and player
                        if (Vector2.Distance(player.transform.position , this.transform.position) > playerDistance)
                        {
                                canFire = false;
                                foundPlayer = false;
                                Vector2 direction = this.transform.position - player.transform.position;
                                rb.AddForce(-direction * moveSpeed);
                        }
                        else
                        {
                                foundPlayer = true;
                        }
                }

                // Make sure enemy is within boundary before it shoots, to avoid shooting from off screen
                if (((this.transform.position.x < 20 && this.transform.position.x > -20) && (this.transform.position.y > -20 && this.transform.position.y < 20)) && foundPlayer)
                {
                        canFire = true;
                }

                // Check if this unit is a mothership or a regular enemy
                if (!damageable.IsAlive && !isMothership && !addPoints)
                {
                        addPoints = true;
                        OnGiveUFOPoints?.Invoke();
                }
                else if (!damageable.IsAlive && isMothership && !addPoints)
                {
                        addPoints = true;
                        OnGiveMothershipPoints?.Invoke();
                }
        }

        IEnumerator RepeatMethodCoroutine()
        {
                // Assign the number of bullets in the inspector to shoot for each burst
                numberOfBulletsToShoot = bulletAmount + 1;

                while (numberOfBulletsToShoot > 1)
                {
                        Fire();
                        yield return new WaitForSeconds(0.75f);
                        numberOfBulletsToShoot--;
                }
        }

        void Fire()
        {
                // Spawn in bullet and rotate based on this rotation
                GameObject enemyBullet = Instantiate(enemyBulletPrefab , this.transform.position , this.transform.rotation);
        }

        public void OnDrawGizmos()
        {
                // Gizmos are great for checking distance and can use them while not in play mode, where raycasts need to be called and in play mode
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(this.transform.position , playerDistance);
        }
}
