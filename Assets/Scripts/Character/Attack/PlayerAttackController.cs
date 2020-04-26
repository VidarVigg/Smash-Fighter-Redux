using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : AttackController
{
    [SerializeField]
    private BoxCollider2D attackCollider;

    public override void Attack()
    {
        attackCollider.enabled = true;
    }

}
