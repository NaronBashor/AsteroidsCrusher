using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
        [SerializeField] private string urlToOpen = "https://splitrockgames.com";

        public void OpenWebsite()
        {
                Application.OpenURL(urlToOpen);
        }
}
