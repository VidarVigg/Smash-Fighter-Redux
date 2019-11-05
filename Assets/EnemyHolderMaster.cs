using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolderMaster : MonoBehaviour
{
    public List<EnemyMaster> activeEnemies = new List<EnemyMaster>();
    public List<GameObject> neighbours = new List<GameObject>();
    public static EnemyHolderMaster INSTANCE;
    public delegate void VoidDelegate(IStateObserver stateObserver);
    public VoidDelegate AddObserver;
    public VoidDelegate RemoveObserver;
    [SerializeField]
    private GameObject floor;

    private void Awake()
    {
        INSTANCE = this;
    }

    public  void AddEnemy(EnemyMaster enemy)
    { 
        activeEnemies.Add(enemy);
        AddObserver.Invoke(enemy);
    }

    public  void RemoveEnemy(EnemyMaster enemy)
    {
        activeEnemies.Remove(enemy);
        RemoveObserver.Invoke(enemy);
    }

    private void Update()
    {
      
    }

    public GameObject Floor
    {
        get { return floor; }
    }
}
