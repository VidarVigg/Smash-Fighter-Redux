using UnityEngine;
using System.Timers;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static InputManager INSTANCE;
    [SerializeField] private InputConfig inputConfig = new InputConfig();

    public TextMeshProUGUI text;

    private KeyCode rightKey = KeyCode.D;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode jumpKey = KeyCode.Space;
    private KeyCode attackKey = KeyCode.Mouse0;
    private KeyCode dashKey = KeyCode.LeftShift;

    public delegate void VoidDelegate();
    public VoidDelegate attackDelegate;

    public delegate void Vector2Delegate(Vector2 aim);
    public Vector2Delegate dashAttackDelegate;
    public Vector2Delegate dashDelegate;



    public delegate void IntDelegate(int variable);

    public delegate void FloatDelegate(float variable);
    public IntDelegate moveDelegate;
    public FloatDelegate jumpDelegate;


    private void Awake()
    {
        if (INSTANCE)
        {
            Destroy(gameObject);
            return;
        }

        INSTANCE = this;

    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
        Dash();
    }

    private void Move()
    {
        int dir = 0;
        bool right = Input.GetKey(rightKey);
        bool left = Input.GetKey(leftKey);
        if (right)
        {
            dir = 1;
        }
        else if (left)
        {
            dir = -1;
        }
        else
        {
            dir = 0;
        }
        moveDelegate?.Invoke(dir);
        GlobalStatistics.playerDirection = dir;
    }

    private void Jump()
    {
        bool jump = Input.GetKey(jumpKey);
        bool release = Input.GetKeyUp(jumpKey);

        if (jump)
        {
            inputConfig.JumpMultiplier += 2f * Time.deltaTime; // todo: change from hard coded value
        }

        if (release)
        {
            if (inputConfig.JumpMultiplier > inputConfig.MaxJumpMultiplierValue)
            {
                inputConfig.JumpMultiplier = inputConfig.MaxJumpMultiplierValue;
            }
            jumpDelegate?.Invoke(inputConfig.JumpMultiplier);
            inputConfig.JumpMultiplier = inputConfig.ResetJumpMultiplier;
        }

    }

    public void Attack()
    {
        bool attack = Input.GetKeyDown(attackKey);

        if (attack)
        {
            attackDelegate.Invoke();
        }

    }

    public void Dash()
    {
        bool dashCharge = Input.GetKeyDown(dashKey);
        bool dash = Input.GetKey(dashKey);
        bool dashRelease = Input.GetKeyUp(dashKey);

        if (dashCharge)
        {
            dashDelegate?.Invoke(MousePosition());

        }
        if (dash)
        {

            //inputConfig.DashMultiplier += inputConfig.DashTick;
            Time.timeScale -= Time.deltaTime * inputConfig.SlowMoMultiplier;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            if (Time.timeScale <= inputConfig.MinTime)
            {
                Time.timeScale = inputConfig.MinTime;
            }

            //if (inputConfig.DashMultiplier >= inputConfig.MaxDashMultiplierValue)
            //{
            //    inputConfig.DashMultiplier = inputConfig.MaxDashMultiplierValue;
            //}

        }
        if (dashRelease)
        {
        //    Time.timeScale = 1;
        //    Time.fixedDeltaTime = 0.02f;
        //    dashDelegate?.Invoke(MousePosition(), inputConfig.DashMultiplier);
            inputConfig.DashMultiplier = inputConfig.ResetDashMultiplier;

        //    //if (inputConfig.DashMultiplier >= inputConfig.MaxDashMultiplierValue)
        //    //{
        //    //    dashAttackDelegate?.Invoke(MousePosition(), inputConfig.DashMultiplier);
        //    //    inputConfig.DashMultiplier = inputConfig.ResetDashMultiplier;
        //    //}
        //    //else
        //    //{
        //    //    dashDelegate?.Invoke(MousePosition());
        //    //    inputConfig.DashMultiplier = inputConfig.ResetDashMultiplier;
        //    //}
        }
    }

    public Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}