﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private CharacterConfig characterConfig = new CharacterConfig();
    [SerializeField]
    private CharacterData characterData = new CharacterData();

    public MovementController movementController; // should not be public. Change This
    public AttackController attackController;

    public bool successfulHit;
    public Rigidbody2D Rigidbody { get; set; }


    #endregion

    #region Properties

    public float Damage
    {
        get { return characterData.Damage; }
        set { characterData.Damage = value; }
    }
    public float Health
    {
        get { return characterData.Health; }
        set { characterData.Health = value; }
    }

    #endregion

    #region Methods

    protected virtual void Awake()
    {
        characterData.Damage = characterConfig.BaseDamage;
        characterData.Health = characterConfig.BaseHealth;
    }

    #endregion


    public abstract void UpdateCurrentState(State newState);
    public abstract void GetHit(Vector2 pos);

    public virtual void ReceiveDamage(float damage)
    {
        Debug.Log("Call from the void");
        characterData.Health -= damage;
        Debug.Log(characterData.Health -= damage);
    }
}
