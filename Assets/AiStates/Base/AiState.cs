using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiState
{
    protected EnemyAIMaster enemy;
    protected Character player;

    public abstract void StateUpdate();

    public AiState (EnemyAIMaster enemy, Character player)
    {
        this.enemy = enemy;
        this.player = player;
    }


}
