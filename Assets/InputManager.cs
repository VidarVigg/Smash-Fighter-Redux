using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager INSTANCE;

    private KeyCode rightKey = KeyCode.D;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode jumpKey = KeyCode.Space;

    public delegate void VoidDelegate();
    public VoidDelegate jumpDelegate;

    public delegate void IntDelegate(int dir);
    public IntDelegate moveDelegate;

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

        if (jump)
        {
            Debug.Log("Jump");
            jumpDelegate.Invoke();
        }
    }
}