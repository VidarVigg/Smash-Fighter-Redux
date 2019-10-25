using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterConfig
{
    #region Fields

    [SerializeField]
    private float baseDamage;
    [SerializeField]
    private float baseHealth;

    #endregion

    #region Properties

    public float BaseHealth
    {
        get { return baseHealth; }
        set { baseHealth = value; }
    }

    public float BaseDamage
    {
        get { return baseDamage; }
        set { baseDamage = value; }
    }

    #endregion

}
