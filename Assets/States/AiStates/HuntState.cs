using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : State
{
    private EnemyMaster enemy;
    private float tick;
    private float attackFrequency;
    private State stateOfInterest;
    private bool hereBecauseIWasNotified;

    public HuntState(Character character, bool hereBecauseIWasNotified = false) : base(character)
    {
        character.stateText.text = this.ToString();
        this.enemy = (EnemyMaster)character;
        this.hereBecauseIWasNotified = hereBecauseIWasNotified;
    }

    public override void EnterState()
    {
        attackFrequency = GenerateRandomNumber(0.5f, 1);
        if (!hereBecauseIWasNotified)
        {
            enemy.DetectNeighbours();

        }
    }

    public override void Update()
    {

        if ((enemy.GetTarget().position - enemy.transform.position).sqrMagnitude > enemy.HuntConfig.minHuntRange)
        {

            enemy.movementController.Move((enemy.GetTarget().position - enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);

        }
        else
        {
            enemy.movementController.Move(Vector2.zero);
        }

        if ((tick += Time.deltaTime) >= attackFrequency)
        {
            tick -= attackFrequency;
            enemy.UpdateCurrentState(new StartAttacking(character));
            attackFrequency = GenerateRandomNumber(0.5f, 1);
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
        enemy.IgnoreNeighbours();
    }

    public override void Handle(State state)
    {

        if (state is DashChargeState)
        {
            enemy.UpdateCurrentState(new FleeState(character));
        }

    }

}