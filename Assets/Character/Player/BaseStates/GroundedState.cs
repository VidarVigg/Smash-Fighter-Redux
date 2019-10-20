using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{
    private PlayerMaster player;
    public GroundedState(Character character) : base(character)
    {
        this.player = (PlayerMaster)character;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
        GroundCheck();

    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 0.2f, player.groundLayer);
        Debug.DrawRay(player.transform.position, Vector2.down * 0.3f, Color.green, 0.1f);
        if (hit.collider != null)
        {
            player.movementController.grounded = true;

            if (!player.movementController.jumping)
            {
                player.movementController.VerticalVelocity = 0;
            }
        }
        else
        {

            player.movementController.grounded = false;
        }

    }

}
