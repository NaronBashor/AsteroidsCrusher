using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damageable : MonoBehaviour
{
        public static event Action OnGiveAsteroidPoints;
        public static event Action OnPlayerDeath;
        public static event Action OnAsteroidDestroyedCount;
        public static event Action AsteroidDestroySound;
        public static event Action OnHitSound;
        public static event Action OnDeathSound;

        SpriteRenderer sprite;

        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;
        [SerializeField] private GameObject explosion;

        public List<Sprite> asteroidCracks = new List<Sprite>();

        private int index;

        private bool isAlive = true;

        public bool IsAlive
        {
                get => isAlive;
                set => isAlive=value;
        }
        public float CurrentHealth
        {
                get => currentHealth;
                set => currentHealth=value;
        }
        public float MaxHealth
        {
                get => maxHealth;
                set => maxHealth=value;
        }

        private void Start()
        {
                // On start get component
                sprite = GetComponent<SpriteRenderer>();
                if (explosion != null)
                {
                        explosion.SetActive(false);
                }

                // On start set health to current health
                CurrentHealth = MaxHealth;

                // On start set index to zero to start at beginning of list
                index = 0;
        }

        public void OnDamage(float damage)
        {
                // If object is alive then take away damage, if health after damage is zero then set to not alive
                if (IsAlive)
                {
                        CurrentHealth -= damage;
                        OnHitSound?.Invoke();
                        if (this.gameObject.CompareTag("Player"))
                        {
                                // If this is attached to player then change color to indicate player is hit
                                sprite.color = Color.red;
                                StartCoroutine(ResetColor());
                        }

                        if (asteroidCracks.Count > 0)
                        {
                                if (CurrentHealth / MaxHealth <= 0.80 && CurrentHealth / MaxHealth > 0.60 && index < asteroidCracks.Count - 1)
                                {
                                        index = 1;
                                        sprite.sprite = asteroidCracks[index];
                                }
                                else if (CurrentHealth / MaxHealth <= 0.60 && CurrentHealth / MaxHealth > 0.50 && index < asteroidCracks.Count - 1)
                                {
                                        index = 2;
                                        sprite.sprite = asteroidCracks[index];
                                }
                                else if (CurrentHealth / MaxHealth <= 0.50 && CurrentHealth / MaxHealth > 0.30 && index < asteroidCracks.Count - 1)
                                {
                                        index = 3;
                                        sprite.sprite = asteroidCracks[index];
                                }
                                else if (CurrentHealth / MaxHealth <= 0.30 && CurrentHealth / MaxHealth > 0.20 && index < asteroidCracks.Count - 1)
                                {
                                        index = 4;
                                        sprite.sprite = asteroidCracks[index];
                                }
                                else if (CurrentHealth / MaxHealth <= 0.20 && CurrentHealth / MaxHealth > 0.10 && index < asteroidCracks.Count - 1)
                                {
                                        index = 5;
                                        sprite.sprite = asteroidCracks[index];
                                }
                                else if (CurrentHealth / MaxHealth <= 0.10 && index < asteroidCracks.Count - 1)
                                {
                                        index = 6;
                                        sprite.sprite = asteroidCracks[index];
                                }
                        }

                        if (this.CurrentHealth <= 0)
                        {
                                OnDeathSound?.Invoke();
                                IsAlive = false;
                                if (this.gameObject.CompareTag("Player"))
                                {
                                        OnPlayerDeath?.Invoke();
                                }
                                this.sprite.enabled = false;
                                if (explosion != null)
                                {
                                        if (this.gameObject.CompareTag("Asteroid"))
                                        {
                                                AsteroidDestroySound?.Invoke();
                                                OnGiveAsteroidPoints?.Invoke();
                                                OnAsteroidDestroyedCount?.Invoke();
                                        }
                                        explosion.SetActive(true);
                                }
                                Destroy(this.gameObject , 0.4f);
                        }
                }
        }

        IEnumerator ResetColor()
        {
                // After delay reset color back to white
                yield return new WaitForSeconds(0.1f);
                sprite.color = Color.white;
        }
}
