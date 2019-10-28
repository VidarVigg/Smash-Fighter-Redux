using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : State
{
    private EnemyMaster enemy;
    private float tick;
    public EnemyDash(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        DisplayState.INSTANCE.Display(this.ToString());
        enemy.movementController.EnemyDash((enemy.GetTarget().position));
        enemy.attackController.Attack();
    }

    public override void ExitState()
    {
        enemy.transform.rotation = Quaternion.identity;
    }

    public override void Handle(State state)
    {

    }

    public override void Update()
    {
        if ((tick += Time.deltaTime) >= enemy.EnemyDashConfig.dashDuration)
        {
            tick -= enemy.EnemyDashConfig.dashDuration;
            enemy.movementController.ResetDash();
            enemy.UpdateCurrentState(new PatrolState(character));
        }
    }
}
