using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private Character damageDealer;
    private Character victim;
    private Character character;
    private bool successfulHit;

    float tick;

    [SerializeField]
    private float attackResetTime = 0.1f;

    public bool SuccessfulHit
    {
        get { return successfulHit; }
    }

    private void Start()
    {

        damageDealer = GetComponentInParent<Character>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if ((tick += Time.deltaTime) >= attackResetTime)
        {
            tick -= attackResetTime;
            if (boxCollider2D.enabled == true)
            {
                boxCollider2D.enabled = false;
                damageDealer.successfulHit = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Player")
        {
            Character victim = collision.GetComponent<Character>();
            victim.ReceiveDamage(damageDealer.damage);
            damageDealer.successfulHit = true;
            victim.GetHit();
        }

    }
}