using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class PlayerMaster : Character, Test
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


    public Rigidbody2D rigidbody;
    private State currentState;

    public LayerMask groundLayer;
    public List<State> baseStates;

    #region Properties

    public DashConfig DashConfig
    {
        get { return dashConfig; }
    }

    public DashChargeConfig DashChargeConfig
    {
        get { return dashChargeConfig; }
    }

    #endregion



    private void Awake()
    {
        //controller = new PlayerController(this, config, data);
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //baseStates = new List<State>() { new GroundedState(this), new GravityState(this) };// Make Components
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();

        movementController.test[0] = this;

        InputManager.INSTANCE.moveDelegate += movementController.Move;
        InputManager.INSTANCE.jumpDelegate += movementController.Jump;
        InputManager.INSTANCE.attackDelegate += attackController.Attack;
        //InputManager.INSTANCE.dashAttackDelegate += movementController.DashAttack;
        InputManager.INSTANCE.dashDelegate += SetDashState;
        //movementController.setDashState += SetDashState;
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }

       

        //for (int i = 0; i < baseStates.Count; i++)
        //{
        //    baseStates[i].Update(); // todo: make components
        //}
    }

    public override void ReceiveDamage(ulong damage)
    {
        Debug.Log("Player Took Damage");
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
        Debug.Log("Call");
        UpdateCurrentState(new PlayerIsHitState(this, pos));
    }

    public void SetDashState(Vector2 pos)
    {
        Debug.Log("Test1");
        UpdateCurrentState(new DashChargeState(this, pos));
    }

    public void Notify()
    {
        Debug.Log("Got notified on Dash");
    }

    public Rigidbody2D Rigidbody2D
    {
        get { return rigidbody; }
    }


}