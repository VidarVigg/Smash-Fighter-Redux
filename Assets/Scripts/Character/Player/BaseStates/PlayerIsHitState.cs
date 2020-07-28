using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsHitState : State
{
    private PlayerMaster player;
    private Vector2 pos;

    public PlayerIsHitState(Character character, Vector2 pos) : base(character)
    {
        this.player = (PlayerMaster)character;
        this.pos = pos;
    }


    public override void EnterState()
    {
        ServiceLocator.AudioService.PlaySound(SoundTypes.PlayerIsHit);
        InputManager.INSTANCE.playerIsHit = true;
        CameraShake.StartShaking();
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }

        player.rigidbody.constraints = RigidbodyConstraints2D.None;
        player.movementController.Move(Vector2.zero);
        player.rigidbody.gravityScale = 1.5f;
        player.rigidbody.AddForce(((Vector2)player.transform.position - pos) * 20, ForceMode2D.Impulse);
        InputManager.INSTANCE.moveDelegate -= player.movementController.Move;
        InputManager.INSTANCE.dashDelegate -= player.SetDashState;
    }

    public override void Update()
    {
        player.transform.Rotate(Vector3.forward, 1.5f);
        if (player.movementController.grounded)
        {
            player.UpdateCurrentState(new NullState(character));
            InputManager.INSTANCE.moveDelegate += player.movementController.Move;
            InputManager.INSTANCE.dashDelegate += player.SetDashState;
        }
    }

    public override void ExitState()
    {
        player.transform.rotation = Quaternion.identity;
        player.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.rigidbody.gravityScale = 0;
        InputManager.INSTANCE.playerIsHit = false;
    }

    public override void Handle(State state)
    {

    }
}
