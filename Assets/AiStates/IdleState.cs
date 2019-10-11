using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullState : AiState
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
}
