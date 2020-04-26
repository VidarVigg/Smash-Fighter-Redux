using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationState : State
{
    EnemyMaster enemy;

    Vector2 position;
    Vector2 velocity;
    public FormationState(Character character, Vector2 position, Vector2 velocity) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        this.position = position;
        this.velocity = position;
    }

    public override void EnterState()
    {
        Debug.Log(enemy.gameObject.name + " Entered " + this.ToString());
        enemy.transform.position = position + Vector2.right;
    }

    public override void Update()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void Handle(State state)
    {

    }

}
