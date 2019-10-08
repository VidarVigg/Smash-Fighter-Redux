using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIMaster : MonoBehaviour
{

    [SerializeField]
    private EnemyAIConfig aIConfig = null;

    [SerializeField]
    private EnemyAIData aIData = null;

    [SerializeField]
    private EnemyAIController aIController = null;

    private void Awake()
    {
        aIController = new EnemyAIController(this, aIConfig, aIData);
    }

    void Start()
    {
        
    }


    void Update()
    {
        aIController.RaycastWallCheck();
    }
}
