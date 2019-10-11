using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Awake()
    {
    }
    void Start()
    {
        movement = GetComponent<MovementController>();
        InputManager.INSTANCE.moveDelegate += movement.Move;
        InputManager.INSTANCE.jumpDelegate += movement.Jump;
    }

    // Update is called once per frame
    void Update()
    {
        //movementManager.Gravity();
        //movementManager.GroundCheck();
    }
}
