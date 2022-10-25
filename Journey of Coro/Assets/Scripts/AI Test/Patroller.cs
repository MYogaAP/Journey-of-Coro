using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex;
    private Vector3 target;
    private float afterChaseTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView eye = GetComponent<FieldOfView>();
        if (eye.CanSeePlayer == false)
        {
            if (afterChaseTime > 0)
            {
                afterChaseTime -= Time.deltaTime;
            } else
            {
                UpdateDestination();
            }
            if (Vector3.Distance(transform.position, target) < 1)
            {
                IncreaseIndex();
                UpdateDestination();
            }
        } else
        {
            afterChaseTime = 5f;
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
