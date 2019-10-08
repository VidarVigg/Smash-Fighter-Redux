using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]

public class EnemyAIData
{

    #region Fields

    [SerializeField] private Player player;

    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitUp;
    private Vector3 right = new Vector2(1, 0);
    private Vector3 left = new Vector2(-1, 0);
    private Vector3 up = new Vector2(0, 1);

    #endregion

    #region Properties

    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    public RaycastHit2D HitRight
    {
        get { return hitRight; }
        set { hitRight = value; }
    }
    public RaycastHit2D HitLeft
    {
        get { return hitLeft; }
        set { hitLeft = value; }
    }
    public RaycastHit2D HitUp
    {
        get { return hitUp; }
        set { hitUp = value; }
    }
    public Vector3 Right
    {
        get { return new Vector3(1, 0); }
    }
    public Vector3 Left
    {
        get { return new Vector3(-1, 0); }
    }
    public Vector3 Up
    {
        get { return new Vector3(0, 1); }
    }

    #endregion

}
