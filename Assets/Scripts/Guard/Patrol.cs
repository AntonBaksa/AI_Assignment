using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    GuardFSM fsm;

    public Transform[] waypoints;
    public float waypointTolerence = 0.5f;

    int currentIndex = 0;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentIndex].position);
        }
    }

   /* public PatrolState(GuardFSM fsm)
    {
        this.fsm = fsm;
    }*/

    public void Patrolling()
    {
        if (waypoints.Length == 0)
        {
            return;
        }


        if (!agent.pathPending && agent.remainingDistance <= waypointTolerence)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentIndex].position);
        }
    }
}
