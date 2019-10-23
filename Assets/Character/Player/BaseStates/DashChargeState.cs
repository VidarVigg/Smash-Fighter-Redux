using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashChargeState : State
{

    private PlayerMaster player;
    private Vector2 mouseCoordinate;


    public DashChargeState(Character character, Vector2 mouseCoordinate) : base(character)
    {
        this.player = (PlayerMaster)character;
        this.mouseCoordinate = mouseCoordinate;
        
    }

    public override void EnterState()
    {
        Debug.Log("Test");

    }

    public override void Update()
    {

        if ((player.DashChargeConfig.dashMultiplier += player.DashChargeConfig.tick) >= player.DashChargeConfig.maxDashMultiplier)
        {
            player.DashChargeConfig.dashMultiplier = player.DashChargeConfig.maxDashMultiplier;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            if (player.DashChargeConfig.dashMultiplier < player.DashChargeConfig.maxDashMultiplier)
            {
                character.UpdateCurrentState(new DashState(character, InputManager.INSTANCE.MousePosition()));
            }
            else
            {
                character.UpdateCurrentState(new DashAttackState(character, InputManager.INSTANCE.MousePosition()));
            }
            player.DashChargeConfig.dashMultiplier = player.DashChargeConfig.reset;
        }
    }

    public override void ExitState()
    {

    }



}
