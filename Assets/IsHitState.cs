using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHitState : State
{
    private EnemyMaster enemy;
    private Rigidbody2D enemyRigidbody;
    private float tick;
    private float stunTime = 0.5f;// move to config file

    public IsHitState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        enemyRigidbody = enemy.Rigidbody;  
        enemyRigidbody.constraints = RigidbodyConstraints2D.None;
        enemyRigidbody.AddForce(((enemy.transform.position - enemy.GetTarget().position).normalized) * 1000);
        enemyRigidbody.gravityScale = 1;
    }

    public override void Update()
    {
        if ((tick += Time.deltaTime) >= stunTime)
        {
            tick -= stunTime;
            enemy.isHit = false;
            enemy.transform.rotation = Quaternion.identity;
            enemy.UpdateCurrentState(new PatrolState(character));

        }
        enemy.transform.Rotate(0, 0, Random.Range(1, 10));
        for (int i = 0; i < enemy.GetWallCollisionArray().Length; i++)
        {
            if (enemy.GetWallCollisionArray()[3].collider != null)
            {
                if (enemy.isHit)
                {
                    enemy.transform.rotation = Quaternion.identity;
                    enemy.UpdateCurrentState(this);
                }
            }
        }

    }

    public override void ExitState()
    {
        enemy.transform.rotation = Quaternion.identity;
        enemy.Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemy.Rigidbody.gravityScale = 0;
    }

}
