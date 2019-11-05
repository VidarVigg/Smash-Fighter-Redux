using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State
{
    EnemyMaster enemy;
    GameObject bulletClone;
    Rigidbody2D rb;
    float tick;


    public ShootState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        enemy.movementController.Move(Vector3.zero);
        character.stateText.text = this.ToString();


    }
    public override void Update()
    {
        enemy.TurnTowardsPlayer(enemy);
        if ((tick += Time.deltaTime) >= 1)
        {
            tick -= 1;
            bulletClone = GameObject.Instantiate(enemy.BulletPrefab, enemy.transform.position, Quaternion.identity, null);
            rb = bulletClone.GetComponent<Rigidbody2D>();
            rb.velocity = (enemy.GetTarget().position - enemy.transform.position).normalized * 40;
            enemy.DecreaseAmmo();
            GameObject.Destroy(bulletClone, 1f);
            if (enemy.AmmoAmt > 0)
            {
                return;
            }
            else
            {
                enemy.UpdateCurrentState(new HuntState(character));

            }
        }
    }

    public override void ExitState()
    {
        enemy.ResetRotation(enemy);
    }

    public override void Handle(State state)
    {

    }



}
