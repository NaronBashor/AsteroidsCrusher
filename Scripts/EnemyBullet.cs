using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
        public static event Action OnBulletSound;

        Rigidbody2D rb;
        Animator anim;

        [SerializeField] private float enemyBulletSpeed;
        [SerializeField] private float enemyBulletDamage;

        private void Start()
        {
                // Get components on start
                rb = GetComponent<Rigidbody2D>();
                anim = GetComponent<Animator>();

                // Play sound when spawned
                OnBulletSound?.Invoke();

                // Assign player to game object for reference
                GameObject player = GameObject.Find("Player");

                // Make sure player is not null to avoid errors
                if (player != null)
                {
                        // Get direction of player facing so bullet goes with the player direction
                        Vector2 direction = player.transform.position - this.transform.position;
                        this.rb.AddForce(direction * enemyBulletSpeed);
                }
        }

        private void Update()
        {
                // Rotate game object to face direction of enemy
                float moveX = this.rb.velocity.x;
                float moveY = this.rb.velocity.y;
                float angle = Mathf.Atan2(moveX , moveY) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(-angle , Vector3.forward);

                // If outside bounds of camera then destroy to reduce objects in game
                if (this.transform.position.x < -30 || this.transform.position.x > 30 || this.transform.position.y < -30 || this.transform.position.y > 30)
                {
                        Destroy(this.gameObject);
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                // Make sure collision is not null before checking
                if (collision != null)
                {
                        // If collision is with player
                        if (collision.CompareTag("Player"))
                        {
                                // Apply damage and start short delay so that bullet explodes on top of play and not outside of player
                                collision.GetComponent<Damageable>().OnDamage(enemyBulletDamage);
                                StartCoroutine(Delay());
                                IEnumerator Delay()
                                {
                                        yield return new WaitForSeconds(.2f);
                                        Hit();
                                }

                        }
                }
        }

        public void Hit()
        {
                anim.SetTrigger("explode");
                this.rb.velocity = Vector2.zero;
                Destroy(this.gameObject , 0.2f);
        }
}
