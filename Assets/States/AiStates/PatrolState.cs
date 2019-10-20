﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    private EnemyMaster enemy;

    public PatrolState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        character.movementController.Move(GetRandomDirection() * enemy.PatrolConfig.patrolMovementSpeed);
    }

    public override void Update()
    {
        RaycastHit2D[] test = enemy.GetWallCollisionArray();

        for (int i = 0; i < test.Length; i++)
        {
            if (test[i].collider != null)
            {
                //SetRandomDirection(CalculateDirection(test[i].point).normalized * enemy.PatrolConfig.patrolMovementSpeed);
                enemy.movementController.Move((CalculateDirection(test[i].point).normalized) * enemy.PatrolConfig.patrolMovementSpeed);
            }
        }

        if ((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude < enemy.PatrolConfig.patrolRange)
        {
            enemy.UpdateCurrentState(new HuntState(character));
        }

    }
    public Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(1, 2), Random.Range(1, 2)).normalized;
    }
    public void SetRandomDirection(Vector2 rand)
    {
        enemy.GetComponent<Rigidbody2D>().velocity = rand;
    }
    public Vector2 CalculateDirection(Vector2 hitPoint)
    {
        Debug.Log((Vector2)enemy.transform.position - hitPoint);
        Vector2 dir = (Vector2)enemy.transform.position - hitPoint;
        dir = (Quaternion.AngleAxis(Random.Range(-180, 180), enemy.transform.position) * dir).normalized * enemy.PatrolConfig.patrolMovementSpeed;
        return dir;
    }

    public override void ExitState()
    {

    }
}