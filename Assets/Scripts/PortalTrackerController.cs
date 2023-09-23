using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PortalTrackerController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private TrailRenderer _trail;
    private PortalController _portal;


    public void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _trail = GetComponent<TrailRenderer>();
        _portal = FindObjectOfType<PortalController>();

        _navMeshAgent.SetDestination(_portal.transform.position);
        StartCoroutine(Finish());
    }


    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(3);

        LeanTween.value(_trail.widthMultiplier, 0, 1).setOnUpdate((float val) =>
        {
            if(_trail == null) LeanTween.cancel(_trail.gameObject);
            _trail.widthMultiplier = val;
        }).setOnComplete(() =>
        {
            LeanTween.cancel(_trail.gameObject);
            Destroy(gameObject);
        });
    }
}
