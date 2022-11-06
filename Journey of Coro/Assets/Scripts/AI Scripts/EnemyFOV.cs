using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] [Range(0,360)] private float angle;
    [SerializeField] GameObject playerRef;
    [SerializeField] private LayerMask targetMask, obstructionMask;
    [SerializeField] bool canSeePlayer = false;

    public float Radius { get => radius; set => radius = value; }
    public float Angle { get => angle; set => angle = value; }
    public GameObject PlayerRef { get => playerRef; set => playerRef = value; }
    public bool CanSeePlayer { get => canSeePlayer; set => canSeePlayer = value; }

    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.25f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, Radius, targetMask);

        if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            } 
            else if (CanSeePlayer)
            {
                CanSeePlayer = false;
            }
        }
    }
}
