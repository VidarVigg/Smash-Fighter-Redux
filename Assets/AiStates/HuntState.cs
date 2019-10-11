using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : AiState
{

    int direction;
    public Rigidbody2D enemyRb;
    private EnemyMaster enemy;

    public HuntState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("Hunt State");
    }

    public override void Update()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = (enemy.GetTarget() - enemy.transform.position).normalized * 2;
        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude > 30)
        {
            enemy.UpdateCurrentState(EnemyAIStates.Patrolling);
        }
    }

}
