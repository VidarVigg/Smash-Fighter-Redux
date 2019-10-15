using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class EnemyMaster : Character
{
    [SerializeField]
    private EnemyConfig aIConfig = null;

    [SerializeField]
    private EnemyData aIData = null;

    private EnemyController aIController = null;

    private State currentState;


    private void Awake()
    {
        aIController = new EnemyController(this, aIConfig, aIData);
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
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
