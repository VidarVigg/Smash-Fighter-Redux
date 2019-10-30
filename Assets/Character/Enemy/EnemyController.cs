using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private EnemyMaster enemyAIMaster;
    private EnemyConfig aIConfig;
    private EnemyData aIData;

    private EnemyController() { }

    public EnemyController(EnemyMaster enemyAIMaster, EnemyConfig aIConfig, EnemyData aIData)
    {

        this.enemyAIMaster = enemyAIMaster;
        this.aIConfig = aIConfig;
        this.aIData = aIData;

    }

    public void Update()
    {
        RaycastWallCheck();
        DebugRays();
    }

    private void RaycastWallCheck()
    {
        aIData.HitRight = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(aIConfig.RayCastOffset, 0, 0), aIData.Right, aIConfig.RaycastLengthHorizontal, aIConfig.LayerMask);
        aIData.HitLeft = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(-aIConfig.RayCastOffset, 0, 0), aIData.Left, aIConfig.RaycastLengthHorizontal, aIConfig.LayerMask);
        aIData.HitUp = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(0, aIConfig.RayCastOffset, 0), aIData.Up, aIConfig.RaycastLengthVertical, aIConfig.LayerMask);
        aIData.HitDown = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(0, -aIConfig.RayCastOffset, 0), aIData.Down, aIConfig.RaycastLengthVertical, aIConfig.LayerMask);

        //Using the null object pattern, all the indexes is set to null
        for (int i = 0; i < aIData.HitPoints.Length; i++)
        {
            aIData.HitPoints[i] = new RaycastHit2D();
        }

        if (aIData.HitRight.collider != null)
        {
            aIData.HitPoints[0] = aIData.HitRight;
        }
        if (aIData.HitLeft.collider != null)
        {
            aIData.HitPoints[1] = aIData.HitLeft;
        }
        if (aIData.HitUp.collider != null)
        {
            aIData.HitPoints[2] = aIData.HitUp;
        }
        if (aIData.HitDown.collider != null)
        {
            aIData.HitPoints[3] = aIData.HitDown;
        }

    }

    private void DebugRays()
    {
        Debug.DrawRay(enemyAIMaster.transform.position + new Vector3(aIConfig.RayCastOffset, 0, 0), aIData.Right * aIConfig.RaycastLengthHorizontal, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position + new Vector3(-aIConfig.RayCastOffset, 0, 0), aIData.Left * aIConfig.RaycastLengthHorizontal, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position + new Vector3(0, aIConfig.RayCastOffset, 0), aIData.Up * aIConfig.RaycastLengthVertical, Color.blue, 0.1f);
        Debug.DrawRay(enemyAIMaster.transform.position + new Vector3(0, -aIConfig.RayCastOffset, 0), aIData.Down * aIConfig.RaycastLengthVertical, Color.blue, 0.1f);
    }



}
