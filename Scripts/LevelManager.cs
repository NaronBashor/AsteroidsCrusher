using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject pauseMenu;

        private void Start()
        {
                gameOverPanel.SetActive(false);
                pauseMenu.SetActive(false);
                settingsPanel.SetActive(false);
                Time.timeScale = 1.0f;
        }

        private void Update()
        {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                        if (settingsPanel.activeSelf)
                        {
                                CloseSettingsPanel();
                                return;
                        }
                        PauseGame();
                }
        }

        public void PauseGame()
        {
                if (Time.timeScale == 0)
                {
                        pauseMenu.SetActive(false);
                        Time.timeScale = 1f;
                }
                else if (Time.timeScale == 1f)
                {
                        pauseMenu.SetActive(true);
                        Time.timeScale = 0f;
                }
        }

        public void OpenSettingsPanel()
        {
                pauseMenu.SetActive(false);
                settingsPanel.SetActive(true);
        }

        public void CloseSettingsPanel()
        {
                pauseMenu.SetActive(true);
                settingsPanel.SetActive(false);
        }

        public void EnableGameOverPanel()
        {
                gameOverPanel.SetActive(true);
        }

        private void OnEnable()
        {
                Damageable.OnPlayerDeath += EnableGameOverPanel;
        }

        private void OnDisable()
        {
                Damageable.OnPlayerDeath -= EnableGameOverPanel;
        }
}
