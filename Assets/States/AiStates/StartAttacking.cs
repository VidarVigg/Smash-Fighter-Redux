﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAttacking : State
{
    private EnemyMaster enemy;
    private float tick;
    private float attackFrequency;
    private Quaternion lookRotation;
    private Vector2 target;

    public StartAttacking(Character character) : base(character)
    {
        character.stateText.text = this.ToString();
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {

        enemy.ShowWeapon();
        // enemy.attackController.Attack();
    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

    }

    public override void Update()
    {
        if ((enemy.GetTarget().position - enemy.transform.position).sqrMagnitude < enemy.AttackConfig.minAttackRange)
        {
            enemy.movementController.Move((enemy.transform.position - enemy.GetTarget().position).normalized * enemy.AttackConfig.attackMovementSpeed);
        }
        else
        { 
            enemy.movementController.Move(Vector3.zero);

            enemy.TurnTowardsPlayer(enemy);

            if((tick += Time.deltaTime) >= enemy.AttackConfig.attackChargeTime)
            {
                tick -= enemy.AttackConfig.attackChargeTime;
                enemy.UpdateCurrentState(new EnemyDash(character));
            }
        }

    }

    //if (enemy.successfulHit)
    //{
    //    enemy.movementController.Move((enemy.transform.position - enemy.GetTarget().position).normalized * enemy.AttackConfig.attackMovementSpeed);

    //}
    //if ((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude >= enemy.HuntConfig.huntRange / 3)
    //{
    //    enemy.UpdateCurrentState(new HuntState(character));
    //}

}


