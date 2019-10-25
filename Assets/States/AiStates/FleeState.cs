﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{

    EnemyMaster enemy;
    Transform target;
    public FleeState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("Enemy Is Fleeing");
    }

    public override void Update()
    {
        target = enemy.GetTarget();
        enemy.movementController.Move(((enemy.transform.position - target.position).normalized) * enemy.FleeConfig.fleeMovementSpeed);
        if(enemy.PlayerStateOfInterest is DashState)
        {
            enemy.UpdateCurrentState(new HuntState(character));
        }
    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {
        
    }
}