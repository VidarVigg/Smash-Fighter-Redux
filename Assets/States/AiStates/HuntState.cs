using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : State
{
    private EnemyMaster enemy;
    private float tick;
    private float attackFrequency;
    private State stateOfInterest;

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

        if ((tick += Time.deltaTime) >= attackFrequency)// should be put in a config file
        {
            tick -= attackFrequency;
            enemy.UpdateCurrentState(new StartAttacking(character));
            attackFrequency = GenerateRandomNumber(1, 3);
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

    public override void Handle(State state)
    {

        if (state is DashChargeState)
        {
            enemy.UpdateCurrentState(new FleeState(character));
        }

    }

}