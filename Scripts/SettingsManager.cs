using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
        public static event Action PlayMusic;
        public static event Action StopMusic;

        [SerializeField] private GameObject buttonOn;
        [SerializeField] private GameObject buttonOff;

        [SerializeField] private Slider volumeSlider;

        private void Start()
        {
                if (PlayerPrefs.GetString("MusicOn") == "True")
                {
                        buttonOn.SetActive(true);
                        buttonOff.SetActive(false);
                }
                else if (PlayerPrefs.GetString("MusicOn") == "False")
                {
                        buttonOff.SetActive(true);
                        buttonOn.SetActive(false);
                }

                volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }

        private void Update()
        {
                PlayerPrefs.SetFloat("Volume" , volumeSlider.value);
        }

        public void SwitchButton()
        {
                if (buttonOn.activeSelf)
                {
                        buttonOn.SetActive(false);
                        buttonOff.SetActive(true);
                        StopMusic?.Invoke();
                        PlayerPrefs.SetString("MusicOn" , "False");
                }
                else if (!buttonOn.activeSelf)
                {
                        buttonOn.SetActive(true);
                        buttonOff.SetActive(false);
                        PlayMusic?.Invoke();
                        PlayerPrefs.SetString("MusicOn" , "True");
                }
        }
}
