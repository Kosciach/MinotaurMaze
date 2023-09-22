using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PortalTrackerController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] TrailRenderer _trail;
    [SerializeField] PortalController _portal;


    public void OnUse()
    {
        _trail.time = 0;
        _trail.widthMultiplier = 0.1f;
        _trail.time = 2;
        _navMeshAgent.SetDestination(_portal.transform.position);
        StartCoroutine(Finish());
    }


    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(6);

        LeanTween.value(_trail.widthMultiplier, 0, 1).setOnUpdate((float val) =>
        {
            _trail.widthMultiplier = val;
        });
    }
}
