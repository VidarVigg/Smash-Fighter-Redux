﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : AttackController
{
    [SerializeField]
    private BoxCollider2D attackCollider;

    public override void Attack()
    {
        Debug.Log("Player Attacked");
        attackCollider.enabled = true;

        //have a trigger on the sword and eneble it on this method

    }

}
