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
    private RaycastHit2D hitDown;
    private Vector2 right;
    private Vector2 left;
    private Vector2 up;
    private Vector2 down;
    [SerializeField]
    private RaycastHit2D[] hitPoints = new RaycastHit2D[4];

    public bool test;

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
    public RaycastHit2D HitDown
    {
        get { return hitDown; }
        set { hitDown = value; }
    }
    public Vector2 Right
    {
        get { return new Vector2(1, 0); }
    }
    public Vector2 Left
    {
        get { return new Vector2(-1, 0); }
    }
    public Vector2 Up
    {
        get { return new Vector2(0, 1); }
    }
    public Vector2 Down
    {
        get { return new Vector2(0, -1); }
    }
    public RaycastHit2D[] HitPoints
    {
        get { return hitPoints; }
        set { hitPoints = value; }

    }

    #endregion

}
