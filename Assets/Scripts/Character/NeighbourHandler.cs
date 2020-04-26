//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NeighbourHandler : MonoBehaviour
//{
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.tag == "Enemy")
//        {
//            EnemyHolderMaster.INSTANCE.neighbours.Add(collision.gameObject);
//        }
//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.tag == "Enemy")
//        {
//            EnemyHolderMaster.INSTANCE.neighbours.Remove(collision.gameObject);
//        }

//    }
//}
