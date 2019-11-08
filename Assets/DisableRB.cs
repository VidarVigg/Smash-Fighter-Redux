using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRB : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private BoxCollider2D col;
    private bool delete;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            delete = true;
            Invoke("DisableRigidBody", 4);
        }
    }

    public void DisableRigidBody()
    {
        rb.simulated = false;
        col.enabled = false;
    }

}
