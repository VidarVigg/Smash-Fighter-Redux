using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private EnemyMaster enemy;
    private float tick;
    private float attackFrequency;
    public AttackState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("Entered Attack State");
        enemy.movementController.Move((enemy.GetTarget().position - enemy.transform.position).normalized * enemy.AttackConfig.attackMovementSpeed);
        enemy.attackController.Attack();

    }
    public override void Update()
    {

        if (enemy.successfulHit)
        {
            Debug.Log("SuccessfulHit");
            enemy.movementController.Move((enemy.transform.position - enemy.GetTarget().position).normalized * enemy.AttackConfig.attackMovementSpeed);
            
        }
        if ((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude >= enemy.HuntConfig.huntRange / 3)
        {
            enemy.UpdateCurrentState(new HuntState(character));
        }

    }

    public override void ExitState()
    {
       
    }



}
