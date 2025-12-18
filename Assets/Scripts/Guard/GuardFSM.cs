using UnityEngine;

public enum EnemyState
{
    Patrolling,
    Chasing,
    Searching,
    Investigate,
    ReturningToPatrol
}

public class GuardFSM : MonoBehaviour
{
    private EnemyState currentState = EnemyState.Patrolling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                break;
            case EnemyState.Chasing:
                break;
            case EnemyState.Searching:
                break;
            case EnemyState.Investigate: 
                break;
            case EnemyState.ReturningToPatrol:
                break;
        }
    }
}
