using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int CurrentWaypointIndex =0;
    //Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination (waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            CurrentWaypointIndex++;
            CurrentWaypointIndex %= waypoints.Length;
            navMeshAgent.SetDestination(waypoints[CurrentWaypointIndex].position);
        }
    }

}


