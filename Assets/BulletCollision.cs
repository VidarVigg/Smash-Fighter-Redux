using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("BulletHit");
            PlayerMaster player = collision.GetComponent<PlayerMaster>();
            player.GetHit(transform.position);
        }
    }
}
