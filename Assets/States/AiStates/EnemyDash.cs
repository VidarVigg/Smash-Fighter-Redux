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

        character.stateText.text = this.ToString();
        enemy.movementController.EnemyDash((enemy.GetTarget().position));
        enemy.attackController.Attack();
        ServiceLocator.AudioService.PlaySound(SoundTypes.EnemyDash);

    }

    public override void ExitState()
    {
        enemy.ResetRotation(enemy);
        enemy.RetractWeapon();
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
            enemy.RetractWeapon();
            enemy.UpdateCurrentState(new MoveAwayState(character));
            //MoveAwayState
        }
        
    }
}
