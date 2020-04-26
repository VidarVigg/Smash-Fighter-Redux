using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{

    EnemyMaster enemy;
    Transform target;
    public FleeState(Character character) : base(character)
    {
        //character.stateText.text = this.ToString();
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {

    }

    public override void Update()
    {
        target = enemy.GetTarget();
        enemy.movementController.Move(((enemy.transform.position - target.position).normalized) * enemy.FleeConfig.fleeMovementSpeed);
        if((enemy.transform.position - target.position).sqrMagnitude >= enemy.FleeConfig.safeDistance)
        {
            enemy.UpdateCurrentState(new PatrolState(character));
        }
    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {
        
    }
}