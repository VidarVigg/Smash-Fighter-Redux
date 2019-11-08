using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMaster : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private EnemySpawnerConfig config;
    [SerializeField]
    private EnemySpawnerData data;
    private static int enemyNumber;
    float tick;
    public static int enemiesInScene;
    [SerializeField]
    private int maxEnemiesAllowed;

    private EnemySpawnerController controller;

    #endregion

    #region Methods

    private void Awake()
    {
        controller = new EnemySpawnerController(this, config, data);
    }
    private void Start()
    {

    }

    private void Update()
    {

        if ((tick += Time.deltaTime) >= 2)
        {
            if (enemiesInScene < maxEnemiesAllowed)
            {
                tick -= 2;
                Spawn();
            }
        }

    }
    public void Spawn()
    {
        enemyNumber++;
        EnemyMaster enemyClone = (EnemyMaster)Instantiate(config.EnemyPrefab, Vector3.zero, Quaternion.identity).GetComponent<EnemyMaster>();
        enemyClone.transform.position = Random.insideUnitCircle.normalized * 3;
        enemyClone.gameObject.name = "Enemy " + enemyNumber.ToString();
        EnemyHolderMaster.INSTANCE.AddEnemy(enemyClone);
        enemiesInScene++;
    }

    #endregion
}
