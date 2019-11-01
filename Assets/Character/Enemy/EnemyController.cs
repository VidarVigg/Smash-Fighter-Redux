using System;
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
        Initialize();

    }

    private void Initialize()
    {
        aIConfig.ThisCollider = enemyAIMaster.GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        RaycastWallCheck();
        DebugRays();
        //FindNeighbours();
        //MarkNeighbours();

    }

    private void RaycastWallCheck()
    {

        aIData.HitRight = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(aIConfig.RayCastOffset, 0, 0), aIData.Right, aIConfig.RaycastLengthHorizontal, aIConfig.LayerMask);
        aIData.HitLeft = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(-aIConfig.RayCastOffset, 0, 0), aIData.Left, aIConfig.RaycastLengthHorizontal, aIConfig.LayerMask);
        aIData.HitUp = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(0, aIConfig.RayCastOffset, 0), aIData.Up, aIConfig.RaycastLengthVertical, aIConfig.LayerMask);
        aIData.HitDown = Physics2D.Raycast(enemyAIMaster.transform.position + new Vector3(0, -aIConfig.RayCastOffset, 0), aIData.Down, aIConfig.RaycastLengthVertical, aIConfig.LayerMask);

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

    internal void AddNeighbour(EnemyMaster enemy)
    {
        aIConfig.neighbours.Add(enemy);
    }
    internal void RemoveNeighbour(EnemyMaster enemy)
    {
        aIConfig.neighbours.Remove(enemy);
    }

    internal void ChangeColor()
    {
        aIConfig.SpriteRenderer.color = aIConfig.NeighbourColor;
    }

    internal void ResetColor()
    {
        aIConfig.SpriteRenderer.color = aIConfig.DefaultColor;
    }


    public void Formation(EnemyMaster neighbour, EnemyMaster host)
    {
        host.transform.position = Vector3.Lerp(host.transform.position, neighbour.transform.position + new Vector3(1, 0, 0), 0.05f);  // enemyAIMaster.transform.position + new Vector3(1, 0, 0);

    }
    //private void FindNeighbours()
    //{
    //    RaycastHit2D[] hits;

    //    for (int i = 0; i < aIConfig.neighbours.Count; i++)
    //    {
    //        aIConfig.neighbours.Clear();
    //    }
    //    hits = Physics2D.CircleCastAll(enemyAIMaster.transform.position, 1, Vector2.zero, 1, aIConfig.NeighbourLayerMask);

    //    for (int i = 0; i < hits.Length; i++)
    //    {

    //        if (hits[i].collider != null)
    //        {
    //            if (hits[i].collider != aIConfig.ThisCollider)
    //            {
    //                Debug.Log(enemyAIMaster.gameObject.name + " has " + hits[i].collider.name + " as neighbour");

    //                if (!aIConfig.neighbours.Contains(hits[i].collider.gameObject))
    //                {
    //                    aIConfig.neighbours.Add(hits[i].collider.gameObject);

    //                }

    //            }
    //        }


    //    }


    //}

    //private void MarkNeighbours()
    //{
    //    for (int i = 0; i < aIConfig.neighbours.Count; i++)
    //    {
    //        aIConfig.neighbours[i].GetComponentInChildren<SpriteRenderer>().color = Color.green;
    //    }
    //}



}
