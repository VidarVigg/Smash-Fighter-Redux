using UnityEngine;
using System.Timers;
using System.Diagnostics;
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

    public delegate void VoidDelegate();
    public VoidDelegate attackDelegate;

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
        Attack();
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
            inputConfig.Multiplier += 2f * Time.deltaTime; // todo: change from hard coded value
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
    public void Attack()
    {
        bool attack = Input.GetKeyDown(attackKey);

        if (attack)
        {
            attackDelegate.Invoke();
        }

    }
}