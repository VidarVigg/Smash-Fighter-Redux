using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAwayState : State
{
    EnemyMaster enemy;
    public MoveAwayState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        enemy.movementController.Move((enemy.GetTarget().position - enemy.transform.position).normalized * 10);
    }
    public override void Update()
    {
        if((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude > enemy.HuntConfig.huntRange)
        {
            enemy.UpdateCurrentState(new HuntState(character, true));
        }
    }


    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

    }

}
