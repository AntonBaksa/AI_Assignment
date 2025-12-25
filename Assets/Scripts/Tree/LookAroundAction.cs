using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Look Around", story: "Rotates", category: "Action", id: "d8a532876c78cbad32f914df6380afd0")]
public partial class LookAroundAction : Action
{
    private Transform self;
    private float degreesPerSec = 70f;
    private float rotatedAmount = 0f;
    protected override Status OnStart()
    {
        self = GameObject.transform;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        float rotation = degreesPerSec * Time.deltaTime;
        self.Rotate(Vector3.up * rotation);
        rotatedAmount += rotation;
        
        if(rotatedAmount >= 360)
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

