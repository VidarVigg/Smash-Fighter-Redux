using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotNotifiedAboutFightState : State
{
    private EnemyMaster enemy;
    private EnemyMaster caller;
    private Vector2 positionOfCaller;

    public GotNotifiedAboutFightState(Character character, EnemyMaster caller) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        character.stateText.text = this.ToString();
        this.caller = caller;
    }

    public override void EnterState()
    {

        enemy.ResetRotation(enemy);

    }

    public override void Update()
    {
        enemy.IgnoreNeighbours();

        if ((positionOfCaller - (Vector2)enemy.transform.position).sqrMagnitude >= enemy.NeighbourConfig.maxDistance)
        {
            enemy.UpdateCurrentState(new ShootState(character));
        }
        else
        {
            positionOfCaller = caller.transform.position;
            enemy.movementController.Move((positionOfCaller - (Vector2)enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);

            if ((positionOfCaller - (Vector2)enemy.transform.position).sqrMagnitude < enemy.NeighbourConfig.minDistance)
            {
                enemy.movementController.Move(Vector3.zero);

                enemy.UpdateCurrentState(new StartAttacking(character));
            }
            return;
        }

    }
    public override void ExitState()
    {

    }
    public override void Handle(State state)
    {

    }

}
