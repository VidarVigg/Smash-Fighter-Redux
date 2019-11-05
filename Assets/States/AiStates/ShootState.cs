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
        character.stateText.text = this.ToString();
        bulletClone = GameObject.Instantiate(enemy.BulletPrefab, enemy.transform.position, Quaternion.identity, null);
        rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.velocity = (enemy.GetTarget().position - enemy.transform.position).normalized * 30;
        enemy.DecreaseAmmo();
        GameObject.Destroy(bulletClone, 1f);

    }
    public override void Update()
    {
        if ((tick += Time.deltaTime) >= 1)
        {
            tick -= 1;

        enemy.UpdateCurrentState(new HuntState(character));
        }
    }

    public override void ExitState()
    {
        
    }

    public override void Handle(State state)
    {
        
    }



}
