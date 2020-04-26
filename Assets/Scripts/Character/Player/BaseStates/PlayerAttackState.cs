using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{

    private PlayerMaster player;

    public PlayerAttackState(Character character) : base(character)
    {
        this.player = (PlayerMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("Player Attacked");
    }

    public override void ExitState()
    {

    }


    public override void Update()
    {

    }

    public override void Handle(State state)
    {

    }

}
