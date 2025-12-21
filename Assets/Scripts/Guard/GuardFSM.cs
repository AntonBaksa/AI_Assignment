using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public class GuardFSM : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public BehaviorGraphAgent behaviorAgent;
    public Unity.Behavior.Blackboard blackboard;

    private IState currentState;

    public Transform[] waypoints;

    public Patrol patrol;
    public Chasing chase;
    public Investigate investigate;

    public float radius;
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstruction;
    public Vector3 lastKnownPosition;

    public bool canSeePlayer;
    public bool hasAlertPosition;
    public bool requestChase;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        behaviorAgent = GetComponent<BehaviorGraphAgent>();
        //blackboard = behaviorAgent.Blackboard;

        patrol = new Patrol(this);
        chase = new Chasing(this);
        investigate = new Investigate(this);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeState(patrol);
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView();
        SyncBlackboard();
        currentState?.Tick();
    }

    void SyncBlackboard()
    {
        /*blackboard.SetValue("canSeePlayer", canSeePlayer);
        blackboard.SetValue("hasAlertPosition", hasAlertPosition);
        blackboard.SetValue("alertPosition", lastKnownPosition);*/
    }

    public void ChangeState(IState newState)
    {
        if (currentState == newState)
            return;

        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void FieldOfView()
    {
        canSeePlayer = false;

        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstruction))
                {
                    canSeePlayer = true;
                    ChangeState(chase);
                }
                else
                {
                    canSeePlayer= false;
                }
                lastKnownPosition = target.position;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            ChangeState(investigate);
        }
    }
}
