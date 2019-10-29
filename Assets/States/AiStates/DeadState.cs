using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{

    private EnemyMaster enemy;

    public DeadState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        character.stateText.text = this.ToString();
        GameObject.Destroy(character.gameObject);
        EnemyHolderMaster.INSTANCE.RemoveEnemy(enemy);
    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

    }

    public override void Update()
    {

    }
}
