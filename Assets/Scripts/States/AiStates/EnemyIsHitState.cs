using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsHitState : State
{
    private EnemyMaster enemy;
    private Rigidbody2D enemyRigidbody;
    private float tick;
    private float stunTime = 1f;// move to config file
    private Vector2 pos;

    public EnemyIsHitState(Character character, Vector2 pos) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        //character.stateText.text = this.ToString();
        this.pos = pos;
    }

    public override void EnterState()
    {

        ServiceLocator.AudioService.PlaySound(SoundTypes.EnemyIsHit);
        enemyRigidbody = enemy.Rigidbody;
        enemyRigidbody.constraints = RigidbodyConstraints2D.None;
        enemyRigidbody.AddForce(pos.normalized * 60, ForceMode2D.Impulse);
        enemyRigidbody.gravityScale = 3;

    }

    public override void Update()
    {

        for (int i = 0; i < enemy.GetWallCollisionArray().Length; i++)
        {
            if (enemy.GetWallCollisionArray()[i].collider != null)
            {
                Debug.Log(enemy.GetWallCollisionArray()[i].collider);
                //FMODUnity.RuntimeManager.PlayOneShot(enemy.enemyIsHitSound);
                ServiceLocator.AudioService.PlaySound(SoundTypes.EnemyDie);
                //enemy.transform.rotation = Quaternion.identity;
                if ((tick += Time.deltaTime) >= stunTime)
                {
                    enemy.UpdateCurrentState(new PatrolState(enemy));
                }

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
