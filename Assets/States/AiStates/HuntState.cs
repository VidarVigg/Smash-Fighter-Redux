using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : State
{
    private EnemyMaster enemy;

    public HuntState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("Entered Hunt");

    }

    public override void Update()
    {
        enemy.movementController.Move((enemy.GetTarget() - enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);
        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude < 3)
        {
            enemy.UpdateCurrentState(new AttackState(character));
        }
        else
        {

        }



        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude > enemy.HuntConfig.huntRange)
        {

            enemy.UpdateCurrentState(new PatrolState(character));

        }
    }

    public override void ExitState()
    {

    }
}