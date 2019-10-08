using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AiState
{
    public PatrolState(EnemyAIMaster enemy, Character player) : base(enemy, player)
    {

    }

    public override void StateUpdate()
    {
        
        enemy.GetComponent<Rigidbody2D>().velocity = GetRandomDirection();
    }
    public Vector2 GetRandomDirection()
    {
        float rand = Random.Range(-1, 1);
        return new Vector2(rand, rand).normalized;
    }
}
