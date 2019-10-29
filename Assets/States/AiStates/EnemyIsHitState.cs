using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsHitState : State
{
    private EnemyMaster enemy;
    private Rigidbody2D enemyRigidbody;
    private float tick;
    private float stunTime = 2f;// move to config file
    private Vector2 pos;

    public EnemyIsHitState(Character character, Vector2 pos) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        character.stateText.text = this.ToString();
        this.pos = pos;
    }

    public override void EnterState()
    {
        enemyRigidbody = enemy.Rigidbody;
        enemyRigidbody.constraints = RigidbodyConstraints2D.None;
        enemyRigidbody.AddForce(((Vector2)enemy.transform.position - pos).normalized * 20, ForceMode2D.Impulse);
        enemyRigidbody.gravityScale = 3;
        
    }

    public override void Update()
    {
        if ((tick += Time.deltaTime) >= stunTime)
        {
            tick -= stunTime;
            enemy.transform.rotation = Quaternion.identity;
           // enemy.UpdateCurrentState(new PatrolState(character));
            if (enemy.Health < 1)
            {

                enemy.UpdateCurrentState(new DeadState(character));

            }

        }
       enemy.transform.Rotate(Vector3.forward, 266 * Time.deltaTime);
        for (int i = 0; i < enemy.GetWallCollisionArray().Length; i++)
        {
            if (enemy.GetWallCollisionArray()[3].collider != null)
            {
                Debug.Log(enemy.GetWallCollisionArray()[3].collider.name);
                enemy.transform.rotation = Quaternion.identity;
                enemy.UpdateCurrentState(new PatrolState(enemy));
                if (enemy.Health < 1)
                {

                    enemy.UpdateCurrentState(new DeadState(character));

                }

            }
        }



    }

    public override void ExitState()
    {
        enemy.Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemy.transform.rotation = Quaternion.identity;
        enemy.Rigidbody.gravityScale = 0;
    }

    public override void Handle(State state)
    {

    }
}
