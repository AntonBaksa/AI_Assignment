using UnityEngine;
using UnityEngine.AI;

public class Patrol : IState
{
    private float waypointTolerence = 0.5f;

    int currentIndex = 0;

    private GuardFSM guard;

    public Patrol(GuardFSM guard)
    {
        this.guard = guard;
    }

    public void Enter()
    {
        guard.agent.speed = 3f;
        if (guard.waypoints.Length > 0)
        {
            guard.agent.SetDestination(guard.waypoints[currentIndex].position);
        }
    }

    public void Tick()
    {
        if (guard.canSeePlayer)
        {
            guard.ChangeState(guard.chase);
                return;
        }

        if (guard.waypoints.Length == 0)
        {
            return;
        }

        if (!guard.agent.pathPending && guard.agent.remainingDistance <= waypointTolerence)
        {
            currentIndex = (currentIndex + 1) % guard.waypoints.Length;
            guard.agent.SetDestination(guard.waypoints[currentIndex].position);
        }
    }

    public void Exit()
    {

    }
}
