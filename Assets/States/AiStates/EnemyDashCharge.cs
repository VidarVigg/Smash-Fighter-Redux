using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashCharge : State
{
    private EnemyMaster enemy;

    public EnemyDashCharge(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        
    }

    public override void Update()
    {
        enemy.transform.Rotate(enemy.GetTarget().transform.position);
    }

    public override void ExitState()
    {
        
    }

    public override void Handle(State state)
    {
        
    }



}
