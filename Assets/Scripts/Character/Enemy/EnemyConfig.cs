using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyConfig
{

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private LayerMask neighbourLayerMask;

    [SerializeField]
    private float raycastLengthHorizontal;

    [SerializeField]
    private float raycastLengthVertical;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float raycastOffset;

    [SerializeField]
    private Color neighbourColor;

    [SerializeField]
    private Color defaultColor;

    private BoxCollider2D thisCollider;

    public List<EnemyMaster> neighbours = new List<EnemyMaster>();

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private CircleCollider2D neighbourDetector;


    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject weapon;

    public LayerMask LayerMask
    {
        get { return layerMask; }
    }
    public LayerMask NeighbourLayerMask
    {
        get { return neighbourLayerMask; }
    }

    public float RaycastLengthHorizontal
    {
        get { return raycastLengthHorizontal; }
        set { raycastLengthHorizontal = value; }
    }
    public float RaycastLengthVertical
    {
        get { return raycastLengthVertical; }
        set { raycastLengthVertical = value; }
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }

    public float RayCastOffset
    {
        get { return raycastOffset; }
        set { raycastOffset = value; }
    }

    public BoxCollider2D ThisCollider
    {
        get { return thisCollider; }
        set { thisCollider = value; }
    }

    public Color DefaultColor
    {
        get { return defaultColor; }
    }

    public Color NeighbourColor
    {
        get { return neighbourColor; }
    }

    public SpriteRenderer SpriteRenderer
    {
        get { return spriteRenderer; }
    }

    public CircleCollider2D NeighborDetector
    {
        get { return neighbourDetector; }
    }

    public GameObject BulletPrefab
    {
        get { return bulletPrefab; }
    }

    public GameObject Weapon
    {
        get { return weapon; }
    }

}
