using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private MovementManager manager = null;
    private MovementConfig config = null;
    private MovementData data = null;

    private MovementController() { }
    public MovementController(MovementManager manager, MovementConfig config, MovementData data)
    {
        this.manager = manager;
        this.config = config;
        this.data = data;
    }

    public void Update()
    {
        Move();
        GroundCheck();
        Gravity();
    }

    private void Move()
    {
        config.Rb.velocity = new Vector2(data.HorizontalDirection * data.MovementSpeed, data.VerticalVelocity);
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(manager.gameObject.transform.position, Vector2.down, 0.4f, config.Lm);
        if (hit.collider != null)
        {
            if (data.PlayerState != MovementStates.Jumping)
            {
                data.PlayerState = MovementStates.Grounded;
                data.VerticalVelocity = 0f;
            }
        }
        else
        {
            if (data.PlayerState == MovementStates.Grounded)
            {
                data.PlayerState = MovementStates.Falling;
            }
        }
    }

    public void Jump()
    {
        if (data.PlayerState != MovementStates.Grounded)
        {
            data.VerticalVelocity = data.JumpForce;
            data.PlayerState = MovementStates.Jumping;
            if (data.VerticalVelocity < 0)
            {
                data.PlayerState = MovementStates.Falling;
            }
        }
    }

    public void Gravity()
    {
        if (data.PlayerState != MovementStates.Grounded)
        {
            data.VerticalVelocity -= data.GravityStrength * Time.deltaTime;
        }
    }
}