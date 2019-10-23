using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsHitState : State
{
    private PlayerMaster player;
    private Vector2 pos;

    public PlayerIsHitState(Character character, Vector2 pos) : base(character)
    {
        this.player = (PlayerMaster)character;
        this.pos = pos;
    }


    public override void EnterState()
    {
        //enemy hit direction
        player.rigidbody.constraints = RigidbodyConstraints2D.None;
        player.movementController.Move(Vector2.zero);
        //player.rigidbody.angularVelocity = 1000;
        player.rigidbody.gravityScale = 1.5f;
        player.rigidbody.AddForce(((Vector2)player.transform.position - pos) * 20, ForceMode2D.Impulse);
        InputManager.INSTANCE.moveDelegate -= player.movementController.Move;  
    }

    public override void Update()
    {
        player.transform.Rotate(Vector3.forward, 1.5f);
        //player.movementController.Move(0, -1);
        
        if (player.movementController.grounded)
        {
            player.UpdateCurrentState(new NullState(character));
            InputManager.INSTANCE.moveDelegate += player.movementController.Move;
        }
    }

    public override void ExitState()
    {
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.rigidbody.gravityScale = 0;
    }

}
