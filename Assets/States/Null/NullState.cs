using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullState : State
{
    public NullState(Character character) : base(character)
    {

    }

    public override void EnterState()
    {

    }


    public override void Update()
    {
        
        Debug.Log("We are In Null State");

    }
    public override void ExitState()
    {

    }
}
