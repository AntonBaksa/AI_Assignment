using UnityEngine;
using UnityEngine.AI;

public class Chasing : IState
{
    private GuardFSM guard;

    private float lostSightTimer;
    private float loseTime = 2;

    public Chasing(GuardFSM guard)
    {
        this.guard = guard;
    }

    public void Enter()
    {
        guard.agent.speed = 5f;

        lostSightTimer = 0f;
    }

    public void Tick()
    {
        guard.agent.SetDestination(guard.player.position);

        if (guard.canSeePlayer)
        {
            lostSightTimer = 0f;
            guard.lastKnownPosition = guard.player.position;
        }
        else
        {
            lostSightTimer += Time.deltaTime;
            if (lostSightTimer >= loseTime)
            {
                guard.ChangeState(guard.investigate);
            }
        }
    }

    public void Exit()
    {
       
    }
}
