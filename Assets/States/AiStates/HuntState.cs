using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : State
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
        Debug.Log("Entered Hunt State");
    }

    public override void Update()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = (enemy.GetTarget() - enemy.transform.position).normalized * 2;
        enemy.attackController.Attack();
        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude > 30)
        {

            enemy.UpdateCurrentState(new PatrolState(character));

        }
    }

    public override void ExitState()
    {
        Debug.Log("Exited Hunt State");
    }
}