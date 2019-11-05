using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmoState : State
{

    EnemyMaster enemy;
    RaycastHit2D floorHit;
    Vector2 floor;
    bool right;
    bool left;


    public CollectAmmoState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        character.stateText.text = this.ToString();
        //enemy.movementController.Move(Vector3.down * 10);
    }

    public override void Update()
    {
        floorHit = Physics2D.Raycast(enemy.transform.position, Vector2.down, 1000, enemy.CollectAmmoConfig.layerMask);
        RaycastHit2D[] wallHits = enemy.GetWallCollisionArray();
        enemy.transform.position = Vector3.Lerp(enemy.transform.position, new Vector3(enemy.transform.position.x, -3, 0), 0.01f);

        Debug.Log(wallHits[0].collider);

        if (!right)
        {
            enemy.movementController.Move(Vector3.right * 5);

            if (wallHits[0].collider != null)
            {
                right = true;
                enemy.movementController.Move(Vector3.zero);
                Debug.Log(enemy.Rigidbody.velocity);
            }
        }
        if (right)
        {
            enemy.movementController.Move(Vector3.left * 5);
            if(wallHits[1].collider != null)
            {
                right = false;
            }
        }

        if (floorHit.collider != null)
        {

            Debug.Log(floorHit.collider);

            enemy.movementController.Move(Vector3.zero);
            enemy.movementController.Move(((Vector3)floorHit.point - enemy.transform.position).normalized * 5);

            if((enemy.transform.position - (Vector3)floorHit.point).sqrMagnitude <= 0.11)
            {

                enemy.IncreaseAmmo();
                enemy.UpdateCurrentState(new ShootState(character));

            }
        }


    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

    }


}
