using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class EnemyMaster : Character
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

    private EnemyController aIController = null;
    private State currentState;
    private Rigidbody2D rigidbody;
    #endregion

    #region Properties

    public Rigidbody2D Rigidbody
    {
        get { return rigidbody; }
        set { rigidbody = value; }
    }
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

    public void UpdateCurrentState(State newState)
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

    public Vector3 GetTarget()
    {
        return aIConfig.Target.position;
    }

    public override void ReceiveDamage(ulong damage)
    {
        Debug.Log("Enemy Took " + damage + " Damage");
        
    }
}
