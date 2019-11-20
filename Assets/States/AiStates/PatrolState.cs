using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    private EnemyMaster enemy;

    public PatrolState(Character character) : base(character)
    {
        //DisplayState.INSTANCE.Display(this.ToString());
        character.stateText.text = this.ToString();
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        enemy.movementController.Move((GetRandomDirection()).normalized * enemy.PatrolConfig.patrolMovementSpeed);
    }

    public override void Update()
    {

        if (enemy.AmmoAmt < 1)
        {
            for (int i = 0; i < AmmoSpawner.INSTANCE.spawnedBullets.Count; i++)
            {
                if (AmmoSpawner.INSTANCE.spawnedBullets[i] != null)
                {
                    enemy.UpdateCurrentState(new CollectAmmoState(character));
                }
            }
        }

        RaycastHit2D[] test = enemy.GetWallCollisionArray();

        for (int i = 0; i < test.Length; i++)
        {
            if (test[i].collider != null)
            {
                enemy.movementController.Move((CalculateDirection(test[i].point).normalized) * enemy.PatrolConfig.patrolMovementSpeed);
            }
        }

        if ((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude < enemy.HuntConfig.huntRange)
        {
            enemy.UpdateCurrentState(new HuntState(character));
        }

    }
    private Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    private void SetRandomDirection(Vector2 rand)
    {
        enemy.GetComponent<Rigidbody2D>().velocity = rand;
    }
    private Vector2 CalculateDirection(Vector2 hitPoint)
    {
        Vector2 dir = (Vector2)enemy.transform.position - hitPoint;
        dir = (Quaternion.AngleAxis(Random.Range(-180, 180), enemy.transform.position) * dir).normalized * enemy.PatrolConfig.patrolMovementSpeed;
        return dir;
    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

    }
}
