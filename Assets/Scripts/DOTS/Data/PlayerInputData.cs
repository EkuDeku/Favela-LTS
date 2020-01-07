using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[GenerateAuthoringComponent]

public struct PlayerInputData : IComponentData
{

    public PlayerInput inputSys;
    public Vector2 move;
    public bool jump;
    

    private void OnMove(InputValue val)
    {

        Debug.Log("Move Set : PlayerInputData");
        move = val.Get<Vector2>();

    }

    private void OnJump(InputValue val)
    {

        Debug.Log("Jump Set : PlayerInputData");
        jump = val.Get<bool>();
        
    }

}