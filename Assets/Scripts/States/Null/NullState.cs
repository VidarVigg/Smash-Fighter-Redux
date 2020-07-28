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

    }

    public override void Update()
    {

    }
    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {
        
    }
}
