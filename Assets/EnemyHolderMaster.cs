using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolderMaster : MonoBehaviour
{
    public List<EnemyMaster> activeEnemies = new List<EnemyMaster>();
    public static EnemyHolderMaster INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    public  void AddEnemy(EnemyMaster enemy)
    {

        activeEnemies.Add(enemy);
    }

    public  void RemoveEnemy(EnemyMaster enemy)
    {
        activeEnemies.Remove(enemy);
    }


}
