using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class EnemyMaster : Character, IStateObserver
{

    #region Fields

    [SerializeField]
    private EnemyConfig aIConfig = null;
    [SerializeField]
    private EnemyData aIData = null;

    [Header("State Configs")]
    [SerializeField]
    private HuntConfig huntConfig;
    [SerializeField]
    private PatrolConfig patrolConfig;
    [SerializeField]
    private AttackConfig attackConfig;
    [SerializeField]
    private FleeConfig fleeConfig;

    private EnemyController aIController = null;
    private State currentState;
    private State playerStateOfInterest;

    #endregion

    #region Properties

    public HuntConfig HuntConfig
    {
        get { return huntConfig; }
    }

    public PatrolConfig PatrolConfig
    {
        get { return patrolConfig; }
    }

    public AttackConfig AttackConfig
    {
        get { return attackConfig; }
    }

    public FleeConfig FleeConfig
    {
        get { return fleeConfig; }
    }

    #endregion

    private void Awake()
    {
        aIController = new EnemyController(this, aIConfig, aIData);
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        UpdateCurrentState(new PatrolState(this));
    }

    void Update()
    {
        currentState.Update();
        RayCastWallCheck();
    }

    public override void UpdateCurrentState(State newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = newState;
        currentState.EnterState();
    }

    private void RayCastWallCheck()
    {
        aIController.RaycastWallCheck();
    }

    public RaycastHit2D[] GetWallCollisionArray()
    {
        return aIData.HitPoints;
    }

    public Transform GetTarget()
    {
        return aIConfig.Target;
    }

    public State PlayerStateOfInterest
    {
        get { return playerStateOfInterest; }
    }

    public override void ReceiveDamage(ulong damage)
    {

        
    }

    public override void GetHit(Vector2 pos)
    {
        UpdateCurrentState(new IsHitState(this, pos));
    }

    public void Notify(State state)
    {
        playerStateOfInterest = state;
        Debug.Log("Enemy Got Notified" + state.ToString());
    }
}
