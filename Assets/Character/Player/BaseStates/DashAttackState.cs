using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackState : State
{
    private PlayerMaster player;
    private float tick;
    private Vector2 mousePos;

    public DashAttackState(Character character, Vector2 mousePos) : base(character)
    {
        this.player = (PlayerMaster)character;
        this.mousePos = mousePos;
    }

    public override void EnterState()
    {
        player.movementController.Dash(InputManager.INSTANCE.MousePosition());
        player.attackController.Attack();
    }

    public override void ExitState()
    {

    }

    public override void Update()
    {
        if ((tick += Time.deltaTime) >= player.DashConfig.dashDuration)
        {
            tick -= player.DashConfig.dashDuration;
            player.movementController.ResetDash();
            
            player.UpdateCurrentState(new NullState(character));
        }
    }

}
