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
    [SerializeField]
    private EnemyDashConfig enemyDashConfig;

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

    public EnemyDashConfig EnemyDashConfig
    {
        get { return enemyDashConfig; }
    }

    public State ActiveState
    {
        get { return currentState; }
    }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        aIController = new EnemyController(this, aIConfig, aIData);
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        aIConfig.Target = FindObjectOfType<PlayerMaster>().transform;
        UpdateCurrentState(new PatrolState(this));
    }

    void Update()
    {
        currentState.Update();
        aIController.Update();
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

    public override void ReceiveDamage(float damage)
    {
        base.ReceiveDamage(damage);
    }

    public override void GetHit(Vector2 pos)
    {
        UpdateCurrentState(new EnemyIsHitState(this, pos));
    }

    public void Notify(State state)
    {
        currentState.Handle(state);
        playerStateOfInterest = state;
    }

    public override void Die()
    {
        //DisplayState.INSTANCE.Display("ded xd");
        
    }
}
