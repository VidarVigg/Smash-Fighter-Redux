using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleState : State
{
    private EnemyMaster enemy;

    public ExampleState(Character character) : base(character)
    {
        enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        //State Was entered
    }

    public override void Update()
    {
        // This update runs as long as ExampleState is CurrentState
    }

    public override void ExitState()
    {
        // When enemy.UpdateCurrentState() is called this code runs
    }
    public override void Handle(State state)
    {
        /* If Player is in a state that the enemy should be notified about 
           while in ExampleState, this can be called.*/
    }

}
