using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemySpawnerConfig
{
    #region Fields

    [SerializeField]
    private GameObject enemyPrefab;

    #endregion

    #region Properties

    public GameObject EnemyPrefab
    {
        get { return enemyPrefab; }
    }

    #endregion
}