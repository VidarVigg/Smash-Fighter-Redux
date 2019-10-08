using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIMaster : MonoBehaviour
{

    [SerializeField]
    private EnemyAIConfig aIConfig = null;

    [SerializeField]
    private EnemyAIData aIData = null;

    [SerializeField]
    private EnemyAIController aIController = null;

    [SerializeField]
    private EnemyStateMachine enemyStateMachine = null;

    private AiState currentState;

    
    private void Awake()
    {
        aIController = new EnemyAIController(this, aIConfig, aIData);
        enemyStateMachine = new EnemyStateMachine(this, aIData.Player); 
    }

    void Start()
    {
        UpdateCurrentState(EnemyAIStates.Idle);
    }


    void Update()
    {
       currentState.StateUpdate();
    }

    public void UpdateCurrentState(EnemyAIStates state)
    {
        currentState = enemyStateMachine.stateDictionary[state];
    }

    public bool GetWallCollisions()
    {

    }

}
