using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController
{
    #region Fields

    private EnemySpawnerMaster master;
    private EnemySpawnerConfig config;
    private EnemySpawnerData data;

    #endregion

    #region Constructors

    public EnemySpawnerController(EnemySpawnerMaster master, EnemySpawnerConfig config, EnemySpawnerData data)
    {
        this.master = master;
        this.config = config;
        this.data = data;
    }

    #endregion

    #region Methods

    #endregion
}
