using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourCheck : MonoBehaviour
{
    EnemyMaster enemy;
    Vector3 velocity;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            velocity = enemy.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("collidingDude collision happened");
            EnemyMaster collidingDude = collision.GetComponent<EnemyMaster>();
            collidingDude.ChangeColor();
            if (enemy.CurrentState is HuntState)
            {
                collidingDude.UpdateCurrentState(new GotNotifiedAboutFightState(collidingDude, enemy));
            }
            //enemy.AddNeighbour(collidingDude);

            //if (enemy.CurrentState is HuntState)
            //{
            //    collidingDude.UpdateCurrentState(new HuntState(collidingDude, true));
            //}
            //if(collidingDude.CurrentState is HuntState)
            //{
            //    enemy.UpdateCurrentState(new HuntState(enemy, true));
            //}



            //if (enemy.myRightPatrolTarget)
            //{
            //    //Debug.Log("i already had a right target - ignore me");
            //    return;
            //}

            //if (collidingDude.myRightPatrolTarget == null)
            //{
            //    //Debug.Log("was null");
            //    collidingDude.myRightPatrolTarget = enemy;
            //    //enemy.UpdateCurrentState(new FormationState(enemy, collidingDude.transform.position, velocity))/* = collidingDude.transform.position + (Vector3.right * 2)*/;
            //}
            //else
            //{
            //    //Debug.Log("wasnt null");
            //    while (collidingDude.myRightPatrolTarget != null)
            //    {
            //        collidingDude = collidingDude.myRightPatrolTarget;
            //    }

            //    if (collidingDude != enemy)
            //    {
            //        collidingDude.myRightPatrolTarget = enemy;
            //    }

            //}

            //if (collidingDude.myRightPatrolTarget == null)
            //{

            //}
            //else
            //{

            //}
            //if (collidingDude.transform.position.x > enemy.transform.position.x)
            //{

            //    Debug.Log(collidingDude.gameObject.name + " is Right of " + enemy.gameObject.name);

            //do
            //{
            //    if (collidingDude.myRightPatrolTarget != null)
            //        collidingDude = collidingDude.myRightPatrolTarget;
            //}
            //while (collidingDude.myRightPatrolTarget != null);
            //
            //collidingDude.myRightPatrolTarget = enemy;
            //enemy.myRightPatrolTarget.UpdateCurrentState(new FormationState(enemy.myRightPatrolTarget));
            //   }

            //enemy rightMost = colliderGubbe;
            //while(rightMost.rightTarget != null)
            //{
            //    rightMost = rightMost.rightTarget;
            //}

            //1 put the object I collided with as "collidingDude" in a local variable
            // 2 Am I to the right of the collidingDude
            // 3 Does the collidingDude have a collidingDude? NO = I am the collidingDude
            // 4 ELSE
            // 5 the new collidingDude is the previous neighbours collidingDude
            // 6 repeat from 3




            //enemy.AddNeighbour(collidingDude);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           
            EnemyMaster collidingDude = collision.GetComponent<EnemyMaster>();
            collidingDude.ChangeColor();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyMaster collidingDude = collision.GetComponent<EnemyMaster>();
            collidingDude.DefaultColor();
            enemy.RemoveNeighbour(collidingDude);
            //if(collidingDude.myRightPatrolTarget == enemy)
            //{
            //    collidingDude.myRightPatrolTarget = null;
            //}
            //else if (enemy.myRightPatrolTarget == collidingDude)
            //{
            //    enemy.myRightPatrolTarget = null;
            //}
            //enemy.RemoveNeighbour(collidingDude);
        }
    }
}
