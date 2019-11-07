using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class PlayerMaster : Character
{
    //[SerializeField]
    //private PlayerConfig config = null;
    //[SerializeField]
    //private PlayerData data = null;
    //private PlayerController controller = null;
    [Header("State Configs")]
    [SerializeField]
    private DashConfig dashConfig;
    [SerializeField]
    private DashChargeConfig dashChargeConfig;
    [SerializeField]
    private PlayerAttackConfig playerAttackConfig;
    public List <IStateObserver> stateObservers;

    public Rigidbody2D rigidbody;
    private State currentState;

    public LayerMask groundLayer;

    #region Properties

    public DashConfig DashConfig
    {
        get { return dashConfig; }
    }

    public DashChargeConfig DashChargeConfig
    {
        get { return dashChargeConfig; }
    }

    public PlayerAttackConfig PlayerAttackConfig
    {
        get { return playerAttackConfig; }
    }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        //controller = new PlayerController(this, config, data);
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {

        stateObservers = new List<IStateObserver>(EnemyHolderMaster.INSTANCE.activeEnemies);
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();

        InputManager.INSTANCE.moveDelegate += movementController.Move;
        InputManager.INSTANCE.jumpDelegate += movementController.Jump;
        InputManager.INSTANCE.attackDelegate += attackController.Attack;
        InputManager.INSTANCE.dashDelegate += SetDashState;
        EnemyHolderMaster.INSTANCE.AddObserver += AddObserver;
        EnemyHolderMaster.INSTANCE.RemoveObserver += RemoveObserver;


    }
    private void Update()
    {

        if (currentState != null)
        {

            currentState.Update();

        }

    }

    public void AddObserver(IStateObserver observer)
    {
        stateObservers.Add(observer);
    }
    public void RemoveObserver(IStateObserver observer)
    {
        stateObservers.Remove(observer);
    }

    public override void ReceiveDamage(float damage)
    {
        base.ReceiveDamage(damage);
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

    public override void GetHit(Vector2 pos)
    {
        UpdateCurrentState(new PlayerIsHitState(this, pos));

    }

    public void SetDashState(Vector2 pos)
    {
        UpdateCurrentState(new DashChargeState(this, pos));
    }

    public void SetAttackState()
    {
        UpdateCurrentState(new PlayerAttackState(this));
    }

    public override void Die()
    {
        
    }

    public Rigidbody2D Rigidbody2D
    {
        get { return rigidbody; }
    }


}