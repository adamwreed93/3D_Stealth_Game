using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _clipToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_clipToPlay, Camera.main.transform.position);
        }
    }
}
