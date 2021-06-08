using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _gameOverCutscene;
    [SerializeField] private MeshRenderer render;

    private void Start()
    {
        MeshRenderer render = GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Color color = new Color(0.6f, 0.11f, 0.11f, 0.3f);
            render.material.SetColor("_TintColor", color);

            _anim.enabled = false;
            StartCoroutine(AlertRoutine());
            
        }
    }

    private IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverCutscene.SetActive(true);
    }
}
