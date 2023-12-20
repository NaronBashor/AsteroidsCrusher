using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
        Rigidbody2D rb;

        [SerializeField] private float damage;
        [SerializeField] private float asteroidSpeed;

        public List<GameObject> targets = new List<GameObject>();

        GameObject targetOne;
        GameObject targetTwo;
        GameObject targetThree;
        GameObject targetFour;
        GameObject targetFive;
        GameObject targetSix;

        private void Start()
        {
                // Get components on start
                rb = GetComponent<Rigidbody2D>();

                // Add all possible spawn locations to list
                targetOne = GameObject.Find("TargetOne");
                targets.Add(targetOne);
                targetTwo = GameObject.Find("TargetTwo");
                targets.Add(targetTwo);
                targetThree = GameObject.Find("TargetThree");
                targets.Add(targetThree);
                targetFour = GameObject.Find("TargetFour");
                targets.Add(targetFour);
                targetFive = GameObject.Find("TargetFive");
                targets.Add(targetFive);
                targetSix = GameObject.Find("TargetSix");
                targets.Add(targetSix);

                // Select random target and set direction based on the current angle
                int randomNumber = UnityEngine.Random.Range(0 , targets.Count);
                Vector2 direction = targets[randomNumber].transform.position - this.transform.position;
                direction.Normalize();

                // Once spawned, add a force to push the asteroid in the given direction
                rb.AddForce(direction * asteroidSpeed);
        }

        private void Update()
        {
                // If this game object leaves the boundaries, destroy it
                if (this.transform.position.x < -50 ||  this.transform.position.y < -50 || this.transform.position.x > 50 || this.transform.position.y > 50)
                {
                        Destroy(this.gameObject);
                }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
                // Make sure collision is not null before running code to avoid errors
                if (collision != null)
                {
                        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
                        {
                                // If collision with player, do damage
                                collision.gameObject.GetComponent<Damageable>().OnDamage(damage);
                        }
                }
        }
}
