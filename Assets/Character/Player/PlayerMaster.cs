using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class PlayerMaster : Character
{
    //[SerializeField]
    //private PlayerConfig config = null;
    //[SerializeField]
    //private PlayerData data = null;
    //private PlayerController controller = null;

    protected Rigidbody2D rigidbody;
    private State currentState;

    public LayerMask groundLayer;
    public List<State> baseStates;

    private void Awake()
    {
        //controller = new PlayerController(this, config, data);
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        baseStates = new List<State>() { new GroundedState(this), new GravityState(this) };
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
        InputManager.INSTANCE.moveDelegate += movementController.Move;
        InputManager.INSTANCE.jumpDelegate += movementController.Jump;
        InputManager.INSTANCE.attackDelegate += attackController.Attack;
    }
    private void Update()
    {
        if (isHit)
        {
            UpdateCurrentState(new PlayerIsHitState(this));
            currentState.Update();
        }
        for (int i = 0; i < baseStates.Count; i++)
        {
            baseStates[i].Update();
        }
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

    public Rigidbody2D Rigidbody2D
    {
        get { return rigidbody; }
    }

}