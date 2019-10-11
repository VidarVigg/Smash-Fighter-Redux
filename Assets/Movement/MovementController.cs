using System;
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{

    [SerializeField]
    private float horizontalDirection;

    [SerializeField]
    private float verticalVelocity;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float gravityStrength;

    public MovementStates playerState;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask lm;

    public float dirx;
    public float diry;


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
        dirx = x;
        diry = y;
        rb.velocity = new Vector2(x, y) * movementSpeed;
    }

    public void Move(int dir)
    {
        horizontalDirection = dir;
        rb.velocity = new Vector2(horizontalDirection * movementSpeed, verticalVelocity);
    }

    public void Move(Vector2 dir)
    {
        Move(dir.x, dir.y);
        
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.3f, lm);
        if (hit.collider != null)
        {
            if (playerState != MovementStates.Jumping)
            {
                verticalVelocity = 0;
                playerState = MovementStates.Grounded;

            }
        }

    }

    public void Jump(float multiplier)
    {

        verticalVelocity = jumpForce * multiplier;
        playerState = MovementStates.Jumping;

    }


    public void Gravity()
    {
        if (playerState != MovementStates.Grounded)
        {

            verticalVelocity -= gravityStrength * Time.deltaTime;

            if (playerState == MovementStates.Jumping)
            {
                if (verticalVelocity < 0)
                {
                    playerState = MovementStates.Falling;
                }
            }
        }
        else
        {
            verticalVelocity = -gravityStrength * Time.deltaTime;
        }
    }

}