using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsHitState : State
{
    private PlayerMaster player;

    public PlayerIsHitState(Character character) : base(character)
    {
        this.player = (PlayerMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("PlayerIsHit");
        player.Rigidbody2D.constraints = RigidbodyConstraints2D.None;
        player.Rigidbody2D.gravityScale = 1;
        InputManager.INSTANCE.moveDelegate -= player.movementController.Move;  
        player.movementController.BaseMovementSpeed = 0;
        
    }

    public override void Update()
    {

    }

    public override void ExitState()
    {

    }

}
