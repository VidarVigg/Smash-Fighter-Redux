using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AiState
{

    public IdleState(EnemyAIMaster enemy, Character player) : base(enemy, player)
    {

    }

    public override void StateUpdate()
    {
        Debug.Log("We are In Idle State");
        PlayerInAggroRange(enemy.transform.position, player.transform.position);
    }

    public void PlayerInAggroRange(Vector2 enemyPosition, Vector2 playerPosition)
    {

        if  ((enemyPosition-playerPosition).sqrMagnitude < 1)
        {
            enemy.UpdateCurrentState(EnemyAIStates.Moving);
            Debug.Log("Moving State");
        }

    }

}
