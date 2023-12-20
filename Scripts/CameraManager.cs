using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
        [SerializeField] private Transform target;

        private void Update()
        {
                // Check to make sure target is not null to avoid errors
                if (target != null)
                {
                        // Restrict camera movement to certain peramaters
                        transform.position = new Vector3(
                                Mathf.Clamp(target.position.x , -11f , 11.5f) ,
                                Mathf.Clamp(target.position.y , -21f , 17f) ,
                                transform.position.z);
                }
        }
}
