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
    private float tick;
    public static int enemiesInScene;
    [SerializeField]
    private int maxEnemiesAllowed;
    [SerializeField]
    private float spawnRate;
    private int[] waves = new int[6] { 1, 2, 4, 8, 16, 32 };
    private EnemySpawnerController controller;

    [SerializeField]
    private int waveIndex = 0;

    #endregion

    #region Methods

    private void Awake()
    {
        controller = new EnemySpawnerController(this, config, data);
        waveIndex = 0;
        enemiesInScene = 0;
    }
    private void Start()
    {
    }

    private void Update()
    {
        if (enemiesInScene == 0)
        {
            maxEnemiesAllowed = waves[waveIndex];
            Debug.Log(waves[waveIndex]);

            for (int i = 0; i < waves[waveIndex]; i++)
            {

                    tick -= spawnRate;
                    Spawn();

            }

            if (waveIndex < 6)
            {
                waveIndex++;

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
