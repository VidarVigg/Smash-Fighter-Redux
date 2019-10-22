using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityState : State
{

    private PlayerMaster player;
    public GravityState(Character character) : base(character)
    {
        this.player = (PlayerMaster)character;
    }

    public override void EnterState()
    {

    }

    public override void Update()
    {
        Gravity();
    }

    public override void ExitState()
    {

    }
    public void Gravity()
    {
        if (!player.movementController.grounded)
        {
            player.movementController.VerticalVelocity -= player.movementController.GravityStrength * Time.deltaTime;

            if (player.movementController.VerticalVelocity < 0)
            {
                player.movementController.jumping = false;
            }

        }
        else
        {
            //player.movementController.VerticalVelocity = 0;
        }
    }

}
