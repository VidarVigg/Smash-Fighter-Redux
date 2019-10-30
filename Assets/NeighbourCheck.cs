using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourCheck : MonoBehaviour
{
    EnemyMaster enemy;


    private void Start()
    {
        enemy = GetComponentInParent<EnemyMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log(enemy.name + " " + collision.name);
            EnemyMaster neighbour = collision.GetComponent<EnemyMaster>();
            neighbour.ChangeColor();
            enemy.AddNeighbour(neighbour);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            EnemyMaster neighbour = collision.GetComponent<EnemyMaster>();
            neighbour.ChangeColor();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyMaster neighbour = collision.GetComponent<EnemyMaster>();
            neighbour.DefaultColor();
            enemy.RemoveNeighbour(neighbour);
        }
    }
}
