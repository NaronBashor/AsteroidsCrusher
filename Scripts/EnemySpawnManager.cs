using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
        public List<Transform> spawnLocations = new List<Transform>();

        [SerializeField] private float initialTimer;
        [SerializeField] private float timer;

        [SerializeField] private bool canSpawn = true;

        [SerializeField] private GameObject enemyUFOPrefab;
        [SerializeField] private GameObject enemyMothershipPrefab;

        private int index = 0;

        private void Start()
        {
                // Set initial values on start
                timer = initialTimer;
                index = 0;
        }

        private void Update()
        {
                // Have timer count down per second
                timer -= Time.deltaTime;

                // If timer reaches zero execute code
                if (timer <= 0 && canSpawn)
                {
                        // Increase index
                        index++;

                        // Every ten levels spawn a mothership instead of a regular UFO
                        if (index % 10 ==  0)
                        {
                                int randomNumber = Random.Range(0 , spawnLocations.Count);
                                GameObject enemy = Instantiate(enemyMothershipPrefab , spawnLocations[randomNumber].position , Quaternion.identity);
                        }
                        else
                        {
                                SpawnEnemy();
                                timer = initialTimer;
                        }
                }
        }

        public void SpawnEnemy()
        {
                // Pick a random spawn location and spawn in an enemy
                int randomNumber = Random.Range(0 , spawnLocations.Count);
                GameObject enemy = Instantiate(enemyUFOPrefab , spawnLocations[randomNumber].position , Quaternion.identity);
        }
}
