using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _nextCamera;

    private void Start()
    {

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = _nextCamera.transform.position;
            Camera.main.transform.rotation = _nextCamera.transform.rotation;
        }
    }

    //Check for Trigger of Player
    //Update main camera to appropriate angle

    //check for trigger
    //debug.log trigger activated

}
