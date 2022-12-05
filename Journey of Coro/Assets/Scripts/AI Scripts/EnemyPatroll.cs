using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatroll : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex;
    private Vector3 target;
    [SerializeField] private float stopMoving;
    [SerializeField] private int changeDistance = 100;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("EWaypoint");
        waypoints = new Transform[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            waypoints[i] = points[i].transform;
        }
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFOV eye = GetComponent<EnemyFOV>();
        if (eye.CanSeePlayer == false)
        {
            if (stopMoving > 0)
            {
                stopMoving -= Time.deltaTime;
            } else
            {
                UpdateDestination();
                if (Vector3.Distance(transform.position, target) < changeDistance)
                {
                    IncreaseIndex();
                }
            }
        } else
        {
            stopMoving = 3f;
            StopMoving();
        }
    }

    void StopMoving()
    {
        target = transform.position;
        agent.SetDestination(target);
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
