using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController), (typeof(AttackController)))]
public class PlayerMaster : Character
{
    [SerializeField]
    private PlayerConfig config = null;

    [SerializeField]
    private PlayerData data = null;

    private PlayerController controller = null;

    public override void ReceiveDamage(ulong damage)
    {
        Debug.Log("Player Took Damage");
    }

    private void Awake()
    {
        controller = new PlayerController(this, config, data);
    }
    void Start()
    {
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
        InputManager.INSTANCE.moveDelegate += movementController.Move;
        InputManager.INSTANCE.jumpDelegate += movementController.Jump;
        InputManager.INSTANCE.attackDelegate += attackController.Attack;
    }

}