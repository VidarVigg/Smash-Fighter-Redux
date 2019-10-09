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
        aIData.HitRight = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Right, aIConfig.RaycastLengthHorizontal, aIConfig.LayerMask);
        aIData.HitLeft = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Left, aIConfig.RaycastLengthHorizontal, aIConfig.LayerMask);
        aIData.HitUp = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Up, aIConfig.RaycastLengthVertical, aIConfig.LayerMask);
        aIData.HitDown = Physics2D.Raycast(enemyAIMaster.transform.position, aIData.Down, aIConfig.RaycastLengthVertical, aIConfig.LayerMask);

        DebugRays();


        for (int i = 0; i < aIData.HitPoints.Length; i++)
        {
            aIData.HitPoints[i] = new RaycastHit2D();
        }

        if (aIData.HitRight.collider != null)
        {
            //Debug.Log("We Hit The Right Wall");
            aIData.HitPoints[0] = aIData.HitRight;
            //aIData.test = true;

        }
        if (aIData.HitLeft.collider != null)
        {
            //Debug.Log("We Hit The Left Wall");
            aIData.HitPoints[1] = aIData.HitLeft;
            //aIData.HitPoints.Add(aIData.HitLeft.point);
            //aIData.test = true;
        }
        if (aIData.HitUp.collider != null)
        {
            //Debug.Log("We hit the roof");
            aIData.HitPoints[2] = aIData.HitUp;
            //aIData.HitPoints.Add(aIData.HitUp.point);
            //aIData.test = true;
        }
        if(aIData.HitDown.collider != null)
        {
            //Debug.Log("We Hit The Floor");
            aIData.HitPoints[3] = aIData.HitDown;
            //aIData.HitPoints.Add(aIData.HitDown.point);
            //aIData.test = true;
        }



    }

    public void DebugRays()
    {
        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Right * aIConfig.RaycastLengthHorizontal, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Left * aIConfig.RaycastLengthHorizontal, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Up * aIConfig.RaycastLengthVertical, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position, aIData.Down * aIConfig.RaycastLengthVertical, Color.blue, 0.1f);
    }

}
