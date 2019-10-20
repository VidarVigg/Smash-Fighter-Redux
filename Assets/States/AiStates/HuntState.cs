using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : State
{
    private EnemyMaster enemy;
    private float tick;
    private float attackFrequency;

    public HuntState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        attackFrequency = GenerateRandomNumber(1, 5);
    }

    public override void Update()
    {
        enemy.movementController.Move((enemy.GetTarget().position - enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);

        if ((tick += Time.deltaTime) >= attackFrequency)
        {
            tick -= attackFrequency;
            enemy.UpdateCurrentState(new AttackState(character));
            attackFrequency = GenerateRandomNumber(1, 5);
        }

        if ((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude > enemy.HuntConfig.huntRange)
        {

            enemy.UpdateCurrentState(new PatrolState(character));

        }
    }
    public float GenerateRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }

    public override void ExitState()
    {

    }
}