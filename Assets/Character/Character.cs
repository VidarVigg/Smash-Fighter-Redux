using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region Fields

    public MovementController movementController; // should not be public. Change This
    public AttackController attackController;

    internal ulong damage = ulong.MaxValue;
    public bool successfulHit;
    protected Material hitMaterial;

    #endregion

    #region Properties



    #endregion

    #region Methods


    #endregion
    public abstract void ReceiveDamage(ulong damage);

}
