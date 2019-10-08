using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyStateMachine
{

    EnemyAIStates aIStates;
    public Dictionary<EnemyAIStates, AiState> stateDictionary;
    private EnemyAIMaster enemy;
    private Player player;

    public EnemyStateMachine(EnemyAIMaster enemy, Player player)
    {
        this.enemy = enemy;
        this.player = player;
        Initalize();
    }

    public void Initalize()
    {
        stateDictionary = new Dictionary<EnemyAIStates, AiState>();
        stateDictionary.Add(EnemyAIStates.Idle, new IdleState(enemy, player));
        stateDictionary.Add(EnemyAIStates.Moving, new MoveState(enemy, player));
        stateDictionary.Add(EnemyAIStates.Patrolling, new PatrolState(enemy, player));
    }


}
