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

    [SerializeField]
    protected MovementStates playerState;


    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected LayerMask lm;

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
        horizontalDirection = dir;
        rb.velocity = new Vector2(horizontalDirection * baseMovementSpeed, verticalVelocity);
    }

    public void Move(Vector2 dir)
    {
        Move(dir.x, dir.y);
        
    }

    public void Jump(float multiplier)
    {

        verticalVelocity = jumpForce * multiplier;
        playerState = MovementStates.Jumping;
    }

    public float BaseMovementSpeed
    {
        set { baseMovementSpeed = value; }
    }



}