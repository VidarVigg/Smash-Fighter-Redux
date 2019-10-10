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
    private float raycastLengthHorizontal;

    [SerializeField]
    private float raycastLengthVertical;

    [SerializeField]
    private Transform target;

    public LayerMask LayerMask
    {
        get { return layerMask; }
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


}
