using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class EnemyMaster : Character, IStateObserver
{

    #region Fields

    [SerializeField]
    private EnemyConfig aIConfig = null;
    [SerializeField]
    private EnemyData aIData = null;

    public List<EnemyMaster> visitor = new List<EnemyMaster>();
    public LineRenderer lr;

   

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
    [SerializeField]
    private NeighbourConfig neighbourConfig;
    [SerializeField]
    private CollectAmmoConfig collectAmmoConfig;
    [SerializeField]
    private EnemyDeathConfig enemyDeathConfig;

    private EnemyController aIController = null;
    private State currentState;
    private State playerStateOfInterest;
    public List<EnemyMaster> enemiesInRange = new List<EnemyMaster>();

    public LayerMask floorLm;

    [SerializeField]
    private GameObject stateTextObject;

    public GameObject stateTextObjectClone;


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

    public State CurrentState
    {
        get { return currentState; }
    }

    public List<EnemyMaster> Neighbours
    {
        get { return aIConfig.neighbours; }
    }

    public NeighbourConfig NeighbourConfig
    {
        get { return neighbourConfig; }
    }

    public CollectAmmoConfig CollectAmmoConfig
    {
        get { return collectAmmoConfig; }
    }

    public int AmmoAmt
    {
        get { return aIData.AmmoAmt; }
    }

    public EnemyDeathConfig EnemyDeathConfig
    {
        get { return enemyDeathConfig; }
    }

    public GameObject BulletPrefab => aIConfig.BulletPrefab;


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
        aIData.AmmoAmt = UnityEngine.Random.Range(1, 3);
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



    internal void AddNeighbour(EnemyMaster enemy)
    {
        aIController.AddNeighbour(enemy);
    }

    internal void DetectNeighbours()
    {
        aIConfig.NeighborDetector.enabled = true;
    }

    internal void IgnoreNeighbours()
    {
        aIConfig.NeighborDetector.enabled = false;
    }

    internal void RemoveNeighbour(EnemyMaster enemy)
    {
        aIController.RemoveNeighbour(enemy);
    }

    internal void ShowWeapon()
    {
        aIController.ShowWeapon();
    }

    internal void RetractWeapon()
    {
        aIController.RetractWeapon();
    }

    internal void ChangeColor()
    {
        aIController.ChangeColor();
    }
    internal void DefaultColor()
    {
        aIController.ResetColor();
    }

    internal void TurnTowardsPlayer(Character turner)
    {
        aIController.TurnTowardsPlayer(turner);
    }
    internal void ResetRotation(Character turner)
    {
        aIController.ResetRotation(turner);
    }

    internal void NotifyNeighbours()
    {
        //aIController.NotifyNeighbours();
    }

    public RaycastHit2D[] GetWallCollisionArray()
    {
        return aIData.HitPoints;
    }

    public Transform GetTarget() => aIConfig.Target;

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

    public void IncreaseAmmo()
    {
        aIData.AmmoAmt += 1;
    }
    public void DecreaseAmmo()
    {
        aIData.AmmoAmt -= 1;
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
