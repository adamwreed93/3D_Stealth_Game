using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField] private GameObject _sleepingGuardCutscene;
    private bool _alreadyPlayedCinematic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_alreadyPlayedCinematic)
        {
            _sleepingGuardCutscene.SetActive(true);
            _alreadyPlayedCinematic = true;
            GameManager.Instance.HasCard = true;
        }
    }
}
