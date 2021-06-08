using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> waypoints;
    private NavMeshAgent _agent;
    private Animator _anim;

    private int _currentTarget;
    private bool _reverse;
    private bool _targetReached;

    public Vector3 coinPos;
    public bool coinTossed;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (waypoints.Count > 0 && waypoints[_currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(waypoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, waypoints[_currentTarget].position);

            if (distance < 4f && (_currentTarget == 0 || _currentTarget == waypoints.Count - 1))
            {
                if (_anim != null)
                _anim.SetBool("Walk", false);
            }
            else
            {
                if (_anim != null)
                _anim.SetBool("Walk", true);
            }


            if (distance < 4.0f && _targetReached == false)
            {
                if (waypoints.Count < 2)
                {
                    return;
                }


                if ((_currentTarget == 0 || _currentTarget == waypoints.Count - 1) && waypoints.Count > 1)
                {
                    _targetReached = true;

                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    if (_reverse == true)
                    {
                        _currentTarget--;

                        if (_currentTarget <= 0)
                        {
                            _reverse = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;
                    }
                }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);

            if (distance < 4f)
            {
                _anim.SetBool("Walk", false);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0 || _currentTarget == waypoints.Count - 1)
        {
            int _randomTime = Random.Range(2, 5);
            yield return new WaitForSeconds(_randomTime);
        }

        if (_reverse)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else
        {
            _currentTarget++;

            if (_currentTarget == waypoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}
