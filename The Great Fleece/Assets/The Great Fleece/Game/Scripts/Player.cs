using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent; //This is a handle.
    private Vector3 _target;
    private bool _coinTossed;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private AudioClip _coinSoundEffect;

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
                //Debug.Log("Hit: " + hitInfo.point);
                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        //Debug.Log(distance);

        if (distance < 2.73f)
        {
            _anim.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && _coinTossed == false)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _anim.SetTrigger("Throw");
                _coinTossed = true;
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSoundEffect, transform.position);
                StartCoroutine(CoinTossCooldown());
                SendAIToCoinSpot(hitInfo.point);
            }
        }
    }

    IEnumerator CoinTossCooldown()
    {
        yield return new WaitForSeconds(15f);
        _coinTossed = false;
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        
        foreach(var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();

            currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPos);
            currentAnim.SetBool("Walk", true);
            currentGuard.coinPos = coinPos;
        }
    }
}
