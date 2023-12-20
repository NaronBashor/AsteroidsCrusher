using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
        public static event Action OnBulletHit;
        public static event Action OnBulletMiss;

        Rigidbody2D rb;

        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletDamage;
        [SerializeField] private float bulletDestroyDelay;

        private void Start()
        {
                // On start get component
                rb = GetComponent<Rigidbody2D>();

                // On start move bullet toward direction facing
                rb.AddRelativeForce(Vector3.up * bulletSpeed);
        }

        private void Update()
        {
                // If outside bounds of camera then destroy to reduce objects in game
                if (this.transform.position.x < -30 || this.transform.position.x > 30 || this.transform.position.y < -30 || this.transform.position.y > 30)
                {
                        OnBulletMiss?.Invoke();
                        Destroy(this.gameObject);
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                // Check if collision is not null, then check if its with asteroid, if so, do damage
                if (collision != null)
                {
                        if (collision.CompareTag("Asteroid"))
                        {
                                collision.GetComponent<Damageable>().OnDamage(bulletDamage);
                                OnBulletHit?.Invoke();
                                Destroy(this.gameObject , bulletDestroyDelay);
                        }
                        if (collision.CompareTag("Enemy"))
                        {
                                collision.GetComponent<Damageable>().OnDamage(bulletDamage);
                                OnBulletHit?.Invoke();
                                Destroy(this.gameObject);
                        }
                }
        }
}
