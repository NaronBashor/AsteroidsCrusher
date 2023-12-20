using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
        [SerializeField] private float points;
        [SerializeField] private float accuracy;
        [SerializeField] private float asteroids;
        [SerializeField] private float survivialTime;
        [SerializeField] private float coins;

        [SerializeField] private TextMeshProUGUI pointsText;
        [SerializeField] private TextMeshProUGUI accuracyText;
        [SerializeField] private TextMeshProUGUI asteroidsText;
        [SerializeField] private TextMeshProUGUI survivalTimeText;
        [SerializeField] private TextMeshProUGUI coinsText;

        private void Start()
        {
                // Get current score when game is over and assign it to panel
                points = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().CurrentScore;
                if (points == 0)
                {
                        pointsText.text = "0";
                }
                else
                {
                        pointsText.text = points.ToString("#,#");
                }

                // Get accuracy when game is over and assign it to panel
                accuracy = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Accuracy;
                accuracyText.text = accuracy.ToString("F0") + "%";

                // Get asteroids destroyed from list count and assign it to panel
                asteroids = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AsteroidsDestroyed;
                asteroidsText.text = asteroids.ToString("F0");

                // Get current time and assign to survival time
                survivialTime = Time.time;
                int minutes = Mathf.FloorToInt(survivialTime / 60f);
                int seconds = Mathf.FloorToInt(survivialTime % 60f);
                string formattedTime = string.Format("{0:00}:{1:00}" , minutes , seconds);
                survivalTimeText.text = formattedTime.ToString();
        }
}
