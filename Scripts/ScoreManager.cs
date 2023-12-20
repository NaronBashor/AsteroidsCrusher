using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
        [SerializeField] private float currentScore = 0;
        [SerializeField] private float accuracy;
        [SerializeField] private float asteroidsDestroyed;

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI playerHealthText;

        public List<string> hitList = new List<string>();
        public List<string> missList = new List<string>();
        public List<string> destroyedAsteroidsList = new List<string>();

        GameObject player;

        public float CurrentScore
        {
                get => currentScore;
                set => currentScore=value;
        }
        public float Accuracy
        {
                get => accuracy;
                set => accuracy=value;
        }
        public float AsteroidsDestroyed
        {
                get => asteroidsDestroyed;
                set => asteroidsDestroyed=value;
        }

        private void Start()
        {
                // Assign player game object for reference
                player = GameObject.Find("Player");

                currentScore = 0;
        }

        private void Update()
        {
                // Have score update as it is accrued
                if (currentScore == 0)
                {
                        scoreText.text = "0";
                }
                else
                {
                        scoreText.text = currentScore.ToString("#,#");
                }

                // Make sure player game object is not null to avoid errors
                if (player != null)
                {
                        // Convert health to percent to display
                        playerHealthText.text = ((player.GetComponent<Damageable>().CurrentHealth / 100) *100).ToString() + "%";
                }

                // Make sure the denominator is not zero to avoid dividing by zero
                if (hitList.Count > 0 || missList.Count > 0)
                {
                        // Find how many bullets have hit a target
                        float numerator = hitList.Count;

                        // Find how many bullets have missed everything
                        float denominator = hitList.Count + missList.Count;

                        // Divide bullets hit by total number of bullets shot to get hit percentage
                        float quotient = numerator / denominator;
                        accuracy = quotient * 100;
                }

                asteroidsDestroyed = destroyedAsteroidsList.Count;
        }

        public void AddHitList()
        {
                hitList.Add("hit");
        }

        public void AddMissList()
        {
                missList.Add("miss");
        }

        public void AddUFOScore()
        {
                currentScore += 100;
        }

        public void AddMothershipScore()
        {
                currentScore += 250;
        }

        public void AddAsteroidScore()
        {
                currentScore += 25;
        }

        public void AddDestroyedAsteroidToList()
        {
                destroyedAsteroidsList.Add("a");
        }

        private void OnEnable()
        {
                EnemyController.OnGiveUFOPoints += AddUFOScore;
                EnemyController.OnGiveMothershipPoints += AddUFOScore;
                Damageable.OnGiveAsteroidPoints += AddAsteroidScore;
                Damageable.OnAsteroidDestroyedCount += AddDestroyedAsteroidToList;
                PlayerBullet.OnBulletHit += AddHitList;
                PlayerBullet.OnBulletMiss += AddMissList;
        }

        private void OnDisable()
        {
                EnemyController.OnGiveUFOPoints -= AddUFOScore;
                EnemyController.OnGiveMothershipPoints -= AddUFOScore;
                Damageable.OnGiveAsteroidPoints -= AddAsteroidScore;
                Damageable.OnAsteroidDestroyedCount -= AddDestroyedAsteroidToList;
                PlayerBullet.OnBulletHit -= AddHitList;
                PlayerBullet.OnBulletMiss -= AddMissList;
        }
}
