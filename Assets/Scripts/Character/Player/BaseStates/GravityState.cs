using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityState : MonoBehaviour
{

    private PlayerMaster player;

    private void Start()
    {
        player = GetComponent<PlayerMaster>();
    }

    private void Update()
    {
        Gravity();
    }
    public void Gravity()
    {
        if (!player.movementController.grounded)
        {
            player.movementController.VerticalVelocity -= player.movementController.GravityStrength * Time.deltaTime;

            if (player.movementController.VerticalVelocity < 0)
            {
                player.movementController.jumping = false;
            }

        }
        else
        {
            //player.movementController.VerticalVelocity = 0;
        }
    }

}
