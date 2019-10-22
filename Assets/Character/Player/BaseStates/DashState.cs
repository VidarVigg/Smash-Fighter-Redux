using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{

    private PlayerMaster player;
    private Vector2 mouseCoordinate;
    
    public DashState(Character character, Vector2 mouseCoordinate) : base(character)
    {
        this.character = (PlayerMaster)character;
        this.mouseCoordinate = mouseCoordinate;
    }

    public override void EnterState()
    {
        Debug.Log("Test");
        character.movementController.Dash(mouseCoordinate);
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
       
    }

}
