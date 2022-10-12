using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FieldOfView eye = GetComponent<FieldOfView>();
        if (eye.CanSeePlayer)
        {
            navMeshAgent.destination = movePositionTransform.position;
        }
    }
}
