using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMaster : Character
{
    [SerializeField]
    private EnemyConfig aIConfig = null;

    [SerializeField]
    private EnemyData aIData = null;

    private EnemyController aIController = null;

    private Dictionary<EnemyAIStates, AiState> stateDictionary = new Dictionary<EnemyAIStates, AiState>();

    private AiState currentState;


    private void Awake()
    {
        aIController = new EnemyController(this, aIConfig, aIData);
        movementManager = GetComponent<MovementManager>();
    }

    void Start()
    {
        stateDictionary.Add(EnemyAIStates.Hunting, new HuntState(this));
        stateDictionary.Add(EnemyAIStates.Patrolling, new PatrolState(this));
        UpdateCurrentState(EnemyAIStates.Patrolling);
    }

    void Update()
    {
        currentState.StateUpdate();
        RayCastWallCheck();
    }

    public void UpdateCurrentState(EnemyAIStates state)
    {
        currentState = stateDictionary[state];
    }

    private void RayCastWallCheck()
    {
       aIController.RaycastWallCheck();
    }

    public void AddStates()
    {

    }

    public RaycastHit2D[] GetWallCollisionArray()
    {
        return aIData.HitPoints;
    }

    public Vector3 GetTarget()
    {
        return aIConfig.Target.position;
    }

}
