using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]

public struct PlayerMovementData : IComponentData
{

    public float speed;
    public float jumpHeight;
    public Vector3 direction;

}