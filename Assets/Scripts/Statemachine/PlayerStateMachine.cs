using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer = 0;
    [SerializeField] private LayerMask wallLayer = 0;
    [SerializeField] private LayerMask grabLayer = 0;
    [SerializeField] private LayerMask interactionLayer = 0;
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float jumpPower = 5.0f;

}
