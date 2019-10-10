using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiState
{
    protected Character character;

    public abstract void StateUpdate();

    public AiState (Character character)
    {
        this.character = character;
    }


}
