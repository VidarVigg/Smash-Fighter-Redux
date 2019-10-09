using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : AiState
{

    int direction;
    public Rigidbody2D enemyRb;
    

    public HuntState(EnemyAIMaster enemy, Character player) : base(enemy, player)
    {

    }

    public override void StateUpdate()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = (player.transform.position - enemy.transform.position).normalized * 5;
        if ((enemy.transform.position - player.transform.position).sqrMagnitude > 30)
        {
            enemy.UpdateCurrentState(EnemyAIStates.Patrolling);
        }
    }

}
