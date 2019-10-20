using System;
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{

    [SerializeField]
    protected float horizontalDirection;

    [SerializeField]
    protected float verticalVelocity;

    [SerializeField]
    protected float jumpForce;

    [SerializeField]
    protected float baseMovementSpeed;

    [SerializeField]
    protected float gravityStrength;

    public bool jumping;

    public bool grounded;

    [SerializeField] protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        // Call global behavior
    }

    public void Move(float x = 1, float y = 1)
    {
        rb.velocity = new Vector2(x, y) * baseMovementSpeed;
    }

    public void Move(int dir)
    {
        Debug.Log("Call");
        horizontalDirection = dir;
        rb.velocity = new Vector2(horizontalDirection * baseMovementSpeed, verticalVelocity);
    }

    public void Move(Vector2 dir)
    {
        Move(dir.x, dir.y);

    }

    public void Jump(float multiplier)
    {
        Debug.Log("Jumping");
        jumping = true;
        verticalVelocity = jumpForce * multiplier;
    }

    public float BaseMovementSpeed
    {
        set { baseMovementSpeed = value; }
    }
    public float VerticalVelocity
    {
        get { return verticalVelocity; }
        set { verticalVelocity = value; }
    }

    public float GravityStrength
    {
        get { return gravityStrength; }
    }


}