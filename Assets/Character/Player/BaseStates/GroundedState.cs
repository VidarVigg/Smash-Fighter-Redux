using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : MonoBehaviour
{

    private PlayerMaster player;

    private void Start()
    {
        player = GetComponent<PlayerMaster>();
    }


    private void Update()
    {
        GroundCheck();
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 0.1f, player.groundLayer);
        Debug.DrawRay(player.transform.position, Vector2.down * 0.3f, Color.green, 0.1f);
        if (hit.collider != null)
        {
            player.movementController.grounded = true;

            if (!player.movementController.jumping)
            {
                player.movementController.VerticalVelocity = 0;
            }
        }
        else
        {

            player.movementController.grounded = false;
        }

    }

}
