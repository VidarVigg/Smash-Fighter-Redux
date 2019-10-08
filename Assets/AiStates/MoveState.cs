using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : AiState
{

    int direction;

    public MoveState(Character affectedCharacter) : base(affectedCharacter)
    {
    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public override void StateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }

        

        // send velocity To whoever is listening;

    }

}
