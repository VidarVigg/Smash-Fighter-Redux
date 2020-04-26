using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourCheck : MonoBehaviour
{
    private EnemyMaster enemy;
    private int numberOfEnemies = 0;

    [SerializeField]
    private int availableListeners;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            EnemyMaster listener = collision.GetComponent<EnemyMaster>();
            listener.ChangeColor();
            numberOfEnemies++;
            
            if (numberOfEnemies <= availableListeners)
            {
                if (enemy.CurrentState is HuntState)
                {
                    listener.UpdateCurrentState(new GotNotifiedAboutFightState(listener, ref enemy));
                }
            }

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
        }
    }
}
