using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DashState : State
{
    private PlayerMaster player;
    private float tick;
    private Vector2 mousePos;

    public DashState(Character character, Vector2 mousePos) : base(character)
    {
        this.player = (PlayerMaster)character;
        this.mousePos = mousePos;
    }

    public override void EnterState()
    {

        player.movementController.VerticalVelocity = 0;
        player.movementController.Dash(InputManager.INSTANCE.MousePosition());


        player.stateObservers.ForEach(x => x.Notify(this));

       // player.stateObservers.Notify(this);

    }

    public override void ExitState()
    {
        
    }

    public override void Handle(State state)
    {
        
    }

    public override void Update()
    {
        if((tick += Time.deltaTime) >= player.DashConfig.dashDuration)
        {
            tick -= player.DashConfig.dashDuration;
            player.movementController.ResetDash();
            //player.UpdateCurrentState(new NullState(character));
        }
    }

}
