using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Awake()
    {
        movementManager = GetComponent<MovementManager>();
    }
    void Start()
    {
        InputManager.INSTANCE.moveDelegate += movementManager.Move;
        InputManager.INSTANCE.jumpDelegate += movementManager.Jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
