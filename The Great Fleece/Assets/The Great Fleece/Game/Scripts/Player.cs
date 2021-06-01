using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent; //This is a handle.
    private Vector3 _target;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // "0" = left mouse button. 
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition); //This casts a ray from the "Main Camera" to the point you clicked.
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.point);
                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        Debug.Log(distance);

        if (distance < 2.73f)
        {
            _anim.SetBool("Walk", false);
        }
    }
}
