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
        //enemy.movementController.Move((enemy.GetTarget() - enemy.transform.position).normalized * enemy.AttackConfig.attackMovementSpeed);
        //enemy.attackController.Attack();
        attackFrequency = GenerateRandomNumber(1, 5);
    }
    public override void Update()
    {
        // Should move this functionality to the hunt state
            enemy.movementController.Move((enemy.GetTarget() - enemy.transform.position).normalized * enemy.AttackConfig.attackMovementSpeed);

        if ((tick += Time.deltaTime) >= attackFrequency)
        {
            tick -= attackFrequency;
            enemy.attackController.Attack();
            attackFrequency = GenerateRandomNumber(1, 5);
            Debug.Log(attackFrequency);
        }
        if (enemy.successfulHit)
        {
            enemy.movementController.Move((enemy.transform.position - enemy.GetTarget()).normalized * enemy.AttackConfig.attackMovementSpeed);

        }
        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude >= enemy.HuntConfig.huntRange / 2)
        {
            enemy.UpdateCurrentState(new HuntState(character));
        }

    }

    public override void ExitState()
    {

    }

    public float GenerateRandomNumber (float min, float max)
    {
        return Random.Range(min, max);
    }

}
