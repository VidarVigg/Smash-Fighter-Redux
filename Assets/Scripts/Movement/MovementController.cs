﻿using System;
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{

    public delegate void TestDelegate();
    public TestDelegate setDashState;

    [SerializeField]
    protected float horizontalDirection;

    [SerializeField]
    protected float verticalVelocity;

    [SerializeField]
    protected float jumpForce;

    [SerializeField]
    protected float baseMovementSpeed;

    [SerializeField]
    protected float dashSpeed;

    [SerializeField]
    protected float gravityStrength;

    [SerializeField]
    protected float dashDuration;

    [SerializeField]
    private int availableDoubleJumps;

    [SerializeField]
    internal int executedJump;

    protected Vector2 dashVelocity;

    float tick;

    public bool jumping;

    public bool grounded;

    public bool dashing;

    public bool chargingDash;

    [SerializeField] protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {

    }

    public void Move(float x = 1, float y = 1)
    {
        rb.velocity = new Vector2(x, y) * baseMovementSpeed;
    }

    public void Move(int dir)
    {
        horizontalDirection = dir;
        rb.velocity = new Vector2(horizontalDirection * baseMovementSpeed, verticalVelocity) + dashVelocity;
    }

    public void Move(Vector2 dir)
    {
        Move(dir.x, dir.y);
    }

    public void Jump(float multiplier)
    {
        if (executedJump < availableDoubleJumps)
        {

            jumping = true;
            executedJump++;
            verticalVelocity = jumpForce * multiplier;

        }
    }

    public void Dash(Vector2 aim)
    {
        //dashing = true;
        dashVelocity = (aim - (Vector2)transform.position).normalized * dashSpeed;
    }
    public void EnemyDash(Vector2 aim)
    {
        dashVelocity = (aim - (Vector2)transform.position).normalized * dashSpeed;
        rb.velocity = dashVelocity;
    }
    public void DashAttack(Vector2 aim)
    {
    }

    public void ResetDash()
    {
        dashVelocity = Vector2.zero;
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