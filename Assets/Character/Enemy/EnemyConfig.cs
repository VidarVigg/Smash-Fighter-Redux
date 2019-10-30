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

    private BoxCollider2D thisCollider;

    public List<GameObject> neighbours = new List<GameObject>();



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


}
