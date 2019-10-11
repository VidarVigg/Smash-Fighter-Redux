using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AiState
{


    private EnemyMaster enemy;
    public float tick;



    public PatrolState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        Debug.Log("Patrol State");
        character.movement.Move(GetRandomDirection());

    }

    public override void Update()
    {
        RaycastHit2D[] test = enemy.GetWallCollisionArray();

        for (int i = 0; i < test.Length; i++)
        {
            if (test[i].collider != null)
            {
                SetRandomDirection(CalculateDirection(test[i].point));
            }
        }

        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude < 20)
        {
            enemy.UpdateCurrentState(EnemyAIStates.Hunting);
        }

    }
    public Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
    }
    public void SetRandomDirection(Vector2 rand)
    {
        enemy.GetComponent<Rigidbody2D>().velocity = rand;
    }
    public Vector2 CalculateDirection(Vector2 hitPoint)
    {
        Debug.Log("Test");
        Vector2 dir = (Vector2)enemy.transform.position-hitPoint;
        dir = (Quaternion.AngleAxis(Random.Range(-180, 180), enemy.transform.position) * dir) * 10;
        return dir;
    }


}
