using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    [SerializeField] private MovementData data = new MovementData();
    [SerializeField] private MovementConfig config = new MovementConfig();
    [SerializeField] private MovementController controller = null;

    private void Awake()
    {
        controller = new MovementController(this, config, data);
        config.Rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        controller.Update();
    }
    public void Move(int dir)
    {
        data.HorizontalDirection = dir;
    }

    public void Jump(float multiplier)
    {
        controller.Jump(multiplier);
    }


}
