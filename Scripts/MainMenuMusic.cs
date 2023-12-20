using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
        [SerializeField] private AudioSource music;

        private void Start()
        {
                music = GetComponent<AudioSource>();
                MusicPlay();
        }

        public void MusicPlay()
        {
                music.Play();
        }

        public void MusicStop()
        {
                music.Stop();
        }

        private void OnEnable()
        {
                SettingsManager.PlayMusic += MusicPlay;
                SettingsManager.StopMusic += MusicStop;
        }

        private void OnDisable()
        {
                SettingsManager.PlayMusic -= MusicPlay;
                SettingsManager.StopMusic -= MusicStop;
        }
}
