﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        ServiceLocator.AudioService.PlaySound(SoundTypes.PlayerDash);
    }

    public override void Update()
    {
       
        if ((player.DashChargeConfig.chargeAmt += player.DashChargeConfig.tick) >= player.DashChargeConfig.maxDashMultiplier)
        {
            player.DashChargeConfig.chargeAmt = player.DashChargeConfig.maxDashMultiplier;
        }
        if (player.DashChargeConfig.chargeAmt >= player.DashChargeConfig.timeBeforeEnemyNotified)
        {    
            player.stateObservers.ForEach(x => x.Notify(this));       
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ServiceLocator.AudioService.StopSound(SoundTypes.PlayerDash, FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            ServiceLocator.AudioService.PlaySound(SoundTypes.PlayerDashRelease);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            if (player.DashChargeConfig.chargeAmt < player.DashChargeConfig.maxDashMultiplier)
            {
                player.UpdateCurrentState(new DashState(character, InputManager.INSTANCE.MousePosition()));
            }
            else
            {
                player.UpdateCurrentState(new DashAttackState(character, InputManager.INSTANCE.MousePosition()));
            }
            player.DashChargeConfig.chargeAmt = player.DashChargeConfig.reset;
        } 
    }

    public override void ExitState()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    public override void Handle(State state)
    {
        
    }
}
