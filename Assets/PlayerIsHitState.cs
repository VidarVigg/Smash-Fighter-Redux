using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsHitState : State
{
    private PlayerMaster player;

    public PlayerIsHitState(Character character) : base(character)
    {
        Debug.Log("SERJESJFE");
        this.player = (PlayerMaster)character;
    }


    public override void EnterState()
    {
        //player.Rigidbody2D.constraints = RigidbodyConstraints2D.None;
        InputManager.INSTANCE.moveDelegate -= player.movementController.Move;  
    }

    public override void Update()
    {
        player.movementController.Move(0, -1);
        if (player.movementController.grounded)
        {
            player.UpdateCurrentState(new NullState(player));
            InputManager.INSTANCE.moveDelegate += player.movementController.Move;
        }
    }

    public override void ExitState()
    {

    }

}
