using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
        [SerializeField] private float spawnTimer;
        [SerializeField] private float timer;
        [SerializeField] private bool canSpawn = true;

        public List<GameObject> asteroidList = new List<GameObject>();
        public List<Transform> spawnLocations = new List<Transform>();

        private void Update()
        {
                // Count down timer
                timer -= Time.deltaTime;

                // If timer is zero, execute code
                if (timer <= 0 && canSpawn)
                {
                        // Reset timer and select a random asteroid, and a random spot to spawn it, then spawn it in
                        timer = spawnTimer;
                        int randomNumberOne = Random.Range(0 , asteroidList.Count);
                        int randomNumberTwo = Random.Range(0 , spawnLocations.Count);
                        GameObject asteroid = Instantiate(asteroidList[randomNumberOne] , spawnLocations[randomNumberTwo].position , Quaternion.identity);
                }
        }
}
