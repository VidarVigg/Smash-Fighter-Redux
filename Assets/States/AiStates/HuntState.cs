using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : State
{
    private EnemyMaster enemy;
    private float tick;
    private float attackFrequency;
    private State stateOfInterest;

    public HuntState(Character character) : base(character)
    {
        character.stateText.text = this.ToString();
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        attackFrequency = GenerateRandomNumber(1, 5);
    }

    public override void Update()
    {
        if ((enemy.GetTarget().position - enemy.transform.position).sqrMagnitude > enemy.HuntConfig.minHuntRange)
        {

          enemy.movementController.Move((enemy.GetTarget().position - enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);

        }
        else
        {
            enemy.movementController.Move(Vector2.zero);
            //ApplyForce();
        }

        if ((tick += Time.deltaTime) >= attackFrequency)// should be put in a config file
        {
            tick -= attackFrequency;
            enemy.UpdateCurrentState(new StartAttacking(character));
            attackFrequency = GenerateRandomNumber(1, 3);
        }

        if ((enemy.transform.position - enemy.GetTarget().position).sqrMagnitude > enemy.HuntConfig.huntRange)
        {
            enemy.UpdateCurrentState(new PatrolState(character));

        }
    }
    public float GenerateRandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

        if (state is DashChargeState)
        {
            enemy.UpdateCurrentState(new FleeState(character));
        }

    }

    //private void CheckObstacleInWay()
    //{
    //    RaycastHit2D hit;
    //    if ((target - enemy.transform.position).sqrMagnitude < enemy.HuntConfig.distanceBeforeObstacleCheck)
    //    {
    //        hit = Physics2D.Raycast(enemy.transform.position, enemy.Rigidbody.velocity.normalized, enemy.HuntConfig.raycastObstacleLength, enemy.HuntConfig.);
    //        Debug.DrawRay(enemy.transform.position, enemy.Rigidbody.velocity.normalized * enemy.HuntConfig.raycastObstacleLength, Color.green);
    //        if (hit.collider != null)
    //        {
    //            Debug.Log(hit.collider.name);
    //            ApplyForce();
    //        }
    //    }
    //}

    //private void ApplyForce()
    //{
    //    Vector3 target = enemy.GetTarget().position;
    //    enemy.Rigidbody.AddForce((enemy.transform.position - target).normalized * 100);
    //}

}