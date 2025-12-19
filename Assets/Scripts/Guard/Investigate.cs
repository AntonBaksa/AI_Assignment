using UnityEngine;

public class Investigate : IState
{
    private GuardFSM guard;

    public Investigate(GuardFSM guard)
    {
        this.guard = guard;
    }

    public void Enter()
    {
        guard.investigateTree.enabled = true;
        guard.agent.SetDestination(guard.lastKnownPosition);
    }

    public void Tick()
    {
        if (guard.canSeePlayer)
        {
            guard.ChangeState(guard.chase);
        }
    }

    public void Exit()
    {
        guard.investigateTree.enabled = false;
    }
}
