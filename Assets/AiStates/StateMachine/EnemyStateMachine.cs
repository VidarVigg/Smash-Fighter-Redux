using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[RequireComponent (typeof (EnemyMaster))]
public class EnemyStateMachine : MonoBehaviour
{

    public Dictionary<EnemyAIStates, AiState> stateDictionary;
    
    public PatrolState patrolState;

    private EnemyMaster enemy;


    public List<AiState> availableStates = new List<AiState>();

    private void Awake()
    {
        Initalize();
    }

    public void Initalize()
    {
        stateDictionary = new Dictionary<EnemyAIStates, AiState>();

    }

}