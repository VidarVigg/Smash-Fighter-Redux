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

    internal void TurnTowardsPlayer(Character enemy)
    {

        Vector2 target = enemyAIMaster.GetTarget().position - enemy.transform.position;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, rotation, 10f * Time.deltaTime);

    }

    internal void ResetRotation(Character turner)
    {
        turner.transform.rotation = Quaternion.identity;
    }

    internal void ShowWeapon()
    {
        aIConfig.Weapon.SetActive(true);
    }

    internal void RetractWeapon()
    {

        aIConfig.Weapon.SetActive(false);

    }

}
