﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Config/Attack Config")]
public class AttackConfig : ScriptableObject
{
    public float attackRange;
    public float attackMovementSpeed;
    public float minAttackRange;
    public float attackChargeTime;
}
