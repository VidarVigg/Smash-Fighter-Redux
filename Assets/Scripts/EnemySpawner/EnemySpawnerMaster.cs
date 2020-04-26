using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private int[] waves = new int[7] { 1, 2, 4, 8, 16, 32, 0 };
    private EnemySpawnerController controller;
    [SerializeField]
    private int startWaveIndex;



    [SerializeField]
    private int waveIndex;

    #endregion

    #region Methods

    private void Awake()
    {
        controller = new EnemySpawnerController(this, config, data);
        enemiesInScene = 0;
    }
    private void Start()
    {
        waveIndex = startWaveIndex;
    }

    private void Update()
    {
        if (enemiesInScene == 0)
        {
            maxEnemiesAllowed = waves[waveIndex];
            Debug.Log(waves[waveIndex]);

            if(waveIndex < 7)
            {
                for (int i = 0; i < waves[waveIndex]; i++)
                {


                    Spawn();


                }
            }


            if (waveIndex <= 5)
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
