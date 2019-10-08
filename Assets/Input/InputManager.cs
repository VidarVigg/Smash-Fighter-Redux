using UnityEngine;
using System.Timers;
using System.Diagnostics;

public class InputManager : MonoBehaviour
{
    public static InputManager INSTANCE;
    [SerializeField] private InputConfig inputConfig = new InputConfig();

    private KeyCode rightKey = KeyCode.D;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode jumpKey = KeyCode.Space;

    public delegate void VoidDelegate();

    public delegate void IntDelegate(int variable);

    public delegate void FloatDelegate(float variable);
    public IntDelegate moveDelegate;
    public FloatDelegate jumpDelegate;

    public Stopwatch timer = new Stopwatch();

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
    }

    private void Jump()
    {
        bool jump = Input.GetKey(jumpKey);
        bool release = Input.GetKeyUp(jumpKey);

        if (jump)
        {
            inputConfig.Multiplier += 1.5f * Time.deltaTime; // todo: change from hard coded value
        }

        if (release)
        {
            if (inputConfig.Multiplier > inputConfig.MaxMultiplierValue)
            {
                inputConfig.Multiplier = inputConfig.MaxMultiplierValue;
            }
            jumpDelegate.Invoke(inputConfig.Multiplier);
            inputConfig.Multiplier = inputConfig.Reset;
        }

    }
}