using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyStateMachine
{

    EnemyAIStates aIStates;
    public Dictionary<EnemyAIStates, AiState> stateDictionary;
    
    public PatrolState patrolState;

    private EnemyAIMaster enemy;
    private Player player;

    public List<AiState> availableStates = new List<AiState>();

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
        stateDictionary.Add(EnemyAIStates.Hunting, new HuntState(enemy, player));
        stateDictionary.Add(EnemyAIStates.Patrolling, new PatrolState(enemy, player));
    }

}