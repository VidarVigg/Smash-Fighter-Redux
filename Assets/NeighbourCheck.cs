using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourCheck : MonoBehaviour
{
    EnemyMaster enemy;
    Vector3 velocity;
    public int numberOfEnemies = 0;
    public EnemyMaster[] test = new EnemyMaster[3];
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
            numberOfEnemies++;
            
            if (numberOfEnemies <= 2)
            {
                if (enemy.CurrentState is HuntState)
                {
                    collidingDude.UpdateCurrentState(new GotNotifiedAboutFightState(collidingDude, enemy));
                }
            }


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
            numberOfEnemies = 0;
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
