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
        guard.behaviorAgent.enabled = true;
        guard.behaviorAgent.SetVariableValue("Search", true);
    }

    public void Tick()
    {
        if (guard.canSeePlayer)
        {
            guard.ChangeState(guard.chase);
        }

        if (guard.requestChase)
        {
            Debug.Log("Request recieved");
            guard.requestChase = false;
            guard.ChangeState(guard.chase);
            return;
        }
    }

    public void Exit()
    {
       guard.behaviorAgent.enabled = false;
    }
}
