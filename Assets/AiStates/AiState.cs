using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiState
{
    protected Character affectedCharacter;

    public abstract void StateUpdate();
    public abstract void EnterState();
    public abstract void ExitState();

    public AiState (Character affectedCharacter)
    {
        this.affectedCharacter = affectedCharacter;
    }


}
