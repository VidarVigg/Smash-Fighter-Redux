using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangle : MonoBehaviour
{

    float tick;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if((tick += Time.deltaTime)>= 5)
        {
            tick -= 5;
            rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        }
    }


}
