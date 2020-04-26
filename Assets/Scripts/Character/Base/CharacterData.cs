using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterData
{
    #region Fields

    [SerializeField]
    private float damage;
    [SerializeField]
    private float health;

    #endregion

    #region Properties

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    #endregion

}
