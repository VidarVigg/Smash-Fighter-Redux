using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullState : State
{
    private PlayerMaster player;

    public NullState(Character character) : base(character)
    {
        this.player = (PlayerMaster)character;
    }

    public override void EnterState()
    {
        //InputManager.INSTANCE.moveDelegate += player.movementController.Move;
    }

    public override void Update()
    {
        
        Debug.Log("We are In Null State");

    }
    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {
        
    }
}
