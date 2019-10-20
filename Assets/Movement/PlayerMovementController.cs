using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementController
{

    #region Fields



    #endregion

    #region Methods

    private void Update()
    {
        Move();
        Gravity();
        GroundCheck();
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

    #endregion

}
