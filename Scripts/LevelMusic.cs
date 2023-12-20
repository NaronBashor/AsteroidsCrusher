using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
        [SerializeField] private AudioClip buttonClick;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip hit;
        [SerializeField] private AudioClip playerShoot;
        [SerializeField] private AudioClip enemyShoot;
        [SerializeField] private AudioClip destroyAsteroid;
        [SerializeField] private AudioClip death;

        [SerializeField] private AudioSource buttonClickSource;
        [SerializeField] private AudioSource backgroundMusicSource;
        [SerializeField] private AudioSource hitSource;
        [SerializeField] private AudioSource playerShootSource;
        [SerializeField] private AudioSource enemyShootSource;
        [SerializeField] private AudioSource destroyAsteroidSource;
        [SerializeField] private AudioSource deathSource;

        public void Start()
        {
                backgroundMusicSource.PlayOneShot(backgroundMusic);
        }

        public void OnPlayButtonClickSound()
        {
                buttonClickSource.PlayOneShot(buttonClick);
        }

        public void OnPlayHitSound()
        {
                hitSource.PlayOneShot(hit);
        }

        public void OnPlayPlayerShootSound()
        {
                playerShootSource.PlayOneShot(playerShoot);
        }

        public void OnPlayEnemyShootSound()
        {
                enemyShootSource.PlayOneShot(enemyShoot);
        }

        public void OnPlayDestroyAsteroidSound()
        {
                destroyAsteroidSource.PlayOneShot(destroyAsteroid);
        }

        public void OnDeathSound()
        {
                deathSource.PlayOneShot(death);
        }

        private void OnEnable()
        {
                EnemyBullet.OnBulletSound += OnPlayEnemyShootSound;
                Damageable.OnHitSound += OnPlayHitSound;
                Damageable.AsteroidDestroySound += OnPlayDestroyAsteroidSound;
                Damageable.OnDeathSound += OnDeathSound;
                PlayerMovement.OnPlayerShootSound += OnPlayPlayerShootSound;
        }

        private void OnDisable()
        {
                EnemyBullet.OnBulletSound -= OnPlayEnemyShootSound;
                Damageable.OnHitSound += OnPlayHitSound;
                Damageable.AsteroidDestroySound += OnPlayDestroyAsteroidSound;
                Damageable.OnDeathSound -= OnDeathSound;
                PlayerMovement.OnPlayerShootSound -= OnPlayPlayerShootSound;
        }
}
