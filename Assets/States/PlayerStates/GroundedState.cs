using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{
    public GroundedState(Character character) : base(character)
    {

    }

    public override void EnterState()
    {
        Debug.Log("Player Is Grounded");
    }


    public override void Update()
    {
        
    }
    public override void ExitState()
    {

    }


}
