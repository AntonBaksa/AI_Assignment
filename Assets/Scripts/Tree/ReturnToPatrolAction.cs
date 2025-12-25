using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ReturnToPatrol", story: "Switch to Patrol", category: "Action", id: "b426b2f5d0037cc494394595172bed5a")]
public partial class ReturnToPatrolAction : Action
{
    protected override Status OnStart()
    {
        var guard = GameObject.GetComponent<GuardFSM>();
        guard.requestReturnToPatrol = true;
        Debug.Log("send request");
        return Status.Success;

    }
}

