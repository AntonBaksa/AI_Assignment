using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SwitchToChase", story: "Switch to Chase", category: "Action", id: "4a48e27c78a7573d3a5c665d17b9f291")]
public partial class SwitchToChaseAction : Action
{
    protected override Status OnStart()
    {
        var guard = GameObject.GetComponent<GuardFSM>();
        guard.requestChase = true;
        Debug.Log("send request");
        return Status.Success;
        
    }
}

