using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotNotifiedAboutFightState : State
{
    private EnemyMaster enemy;
    private EnemyMaster caller;
    private Vector2 positionOfCaller;

    public GotNotifiedAboutFightState(Character character, ref EnemyMaster caller) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        character.stateText.text = this.ToString() + caller.name;
        this.caller = caller;
    }

    public override void EnterState()
    {

        enemy.ResetRotation(enemy);

    }

    public override void Update()
    {
        enemy.IgnoreNeighbours();

        if ((positionOfCaller - (Vector2)enemy.transform.position).sqrMagnitude >= enemy.NeighbourConfig.maxDistance && enemy.AmmoAmt > 0)
        {

            enemy.UpdateCurrentState(new ShootState(character));


        }
        else
        {
            if (caller)
            {
                positionOfCaller = caller.transform.position;

            }
            enemy.movementController.Move((positionOfCaller - (Vector2)enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);

            if ((positionOfCaller - (Vector2)enemy.transform.position).sqrMagnitude < enemy.NeighbourConfig.minDistance)
            {
                enemy.movementController.Move(Vector3.zero);
                enemy.UpdateCurrentState(new StartAttacking(character));
            }
            return;
        }
        if ((positionOfCaller - (Vector2)enemy.transform.position).sqrMagnitude >= enemy.NeighbourConfig.maxDistance && enemy.AmmoAmt == 0)
        {
            for (int i = 0; i < AmmoSpawner.INSTANCE.spawnedBullets.Count; i++)
            {
                if (AmmoSpawner.INSTANCE.spawnedBullets[i] != null)
                {
                    //chosenBullet = AmmoSpawner.INSTANCE.spawnedBullets[i];
                    enemy.UpdateCurrentState(new CollectAmmoState(character));
                }
                else
                {
                    enemy.UpdateCurrentState(new PatrolState(character));
                }
            }
        }


    }
    public override void ExitState()
    {

    }
    public override void Handle(State state)
    {

    }

}
