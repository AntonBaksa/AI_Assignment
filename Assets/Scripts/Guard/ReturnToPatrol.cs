using UnityEngine;

public class ReturnToPatrol : IState
{
    private GuardFSM guard;

    public ReturnToPatrol(GuardFSM guard)
    {
        this.guard = guard;
    }

    public void Enter()
    {
        guard.agent.speed = 3f;
    }

    public void Tick()
    {
        Debug.Log("Returning to patrol");
        
    }

    public void Exit()
    {

    }
}
