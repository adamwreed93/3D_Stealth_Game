using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _startCamera;

    private void Start()
    {
        transform.position = _startCamera.position;
        transform.rotation = _startCamera.rotation;
    }


    void Update()
    {
        transform.LookAt(_target);
    }
}
