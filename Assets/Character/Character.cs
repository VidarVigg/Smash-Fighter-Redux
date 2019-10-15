using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public MovementController movementController; // should not be public. Change This
    public AttackController attackController;

    public abstract void ReceiveDamage(ulong damage);
    internal ulong damage = ulong.MaxValue;

}
