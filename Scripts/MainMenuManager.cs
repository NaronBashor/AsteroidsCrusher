using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject creditsMenu;
        [SerializeField] private GameObject armoryMenu;
        [SerializeField] private GameObject spaceshipMenu;

        private void Start()
        {
                settingsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                armoryMenu.SetActive(false);
                spaceshipMenu.SetActive(false);
        }

        private void Update()
        {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                        if (settingsMenu.activeSelf)
                        {
                                CloseSettingsMenu();
                        }
                        if (armoryMenu.activeSelf)
                        {
                                CloseArmoryMenu();
                        }
                        if (spaceshipMenu.activeSelf)
                        {
                                CloseSpaceshipMenu();
                                OpenArmoryMenu();
                        }
                        if (creditsMenu.activeSelf)
                        {
                                creditsMenu.SetActive(false);
                        }
                }
        }

        public void OpenSpaceshipMenu()
        {
                spaceshipMenu.SetActive(true);
                CloseArmoryMenu();
        }

        public void CloseSpaceshipMenu()
        {
                spaceshipMenu.SetActive(false);
                OpenArmoryMenu();
        }

        public void OpenArmoryMenu()
        {
                armoryMenu.SetActive(true);
        }

        public void CloseArmoryMenu()
        {
                armoryMenu.SetActive(false);
        }

        public void OpenCreditsMenu()
        {
                creditsMenu.SetActive(true);
        }

        public void CloseCreditsMenu()
        {
                creditsMenu.SetActive(false);
        }

        public void OpenSettingsMenu()
        {
                settingsMenu.SetActive(true);
        }

        public void CloseSettingsMenu()
        {
                settingsMenu.SetActive(false);
        }
}
