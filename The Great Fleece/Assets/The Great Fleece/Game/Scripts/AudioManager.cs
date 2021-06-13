using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    [SerializeField] private AudioSource _voiceOver;


    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is NULL!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this; //Makes "_instance" equal this script.
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        _voiceOver.clip = clipToPlay;
        _voiceOver.Play();
    }
}
