using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController
{
    private EnemyAIMaster enemyAIMaster;
    private EnemyAIConfig aIConfig;
    private EnemyAIData aIData;

    private EnemyAIController() { }

    public EnemyAIController(EnemyAIMaster enemyAIMaster, EnemyAIConfig aIConfig, EnemyAIData aIData)
    {
        this.enemyAIMaster = enemyAIMaster;
        this.aIConfig = aIConfig;
        this.aIData = aIData;
    }

    public void RaycastWallCheck()
    {
        aIData.HitRight = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Right, aIConfig.RaycastLength, aIConfig.LayerMask);
        aIData.HitLeft = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Left, aIConfig.RaycastLength, aIConfig.LayerMask);
        aIData.HitUp = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Up, aIConfig.RaycastLength, aIConfig.LayerMask);

        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Right * aIConfig.RaycastLength, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Left * aIConfig.RaycastLength, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Up * aIConfig.RaycastLength, Color.blue, 0.1f);

        if (aIData.HitRight.collider != null)
        {
            Debug.Log("We Hit The Right Wall");
        }
        if (aIData.HitLeft.collider != null)
        {
            Debug.Log("We Hit The Left Wall");
        }
        if (aIData.HitUp.collider != null)
        {
            Debug.Log("We hit the roof");
        }
    }

}
