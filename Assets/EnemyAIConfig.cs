using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyAIConfig
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private float raycastLength;

    public LayerMask LayerMask
    {
        get { return layerMask; }
    }

    public float RaycastLength
    {
        get { return raycastLength; }
        set { raycastLength = value; }
    }
}
