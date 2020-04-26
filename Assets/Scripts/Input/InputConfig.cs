using UnityEngine;
using System;

[Serializable]
public class InputConfig 
{

    [SerializeField] 
    private float maxJumpMultiplierValue;

    [SerializeField] 
    private float maxDashMultiplierValue;
    [SerializeField] 
    private float jumpMultiplier;
    [SerializeField] 
    private float resetJumpMultiplier;
    [SerializeField]
    private float dashMultiplier;
    [SerializeField]
    private float resetDashMultiplier;
    [SerializeField]
    private float slowMoMultiplier;
    [SerializeField]
    private float dashTick;
    [SerializeField]
    private float minTime;

    public float MaxJumpMultiplierValue
    {
        get { return maxJumpMultiplierValue; }
        set { maxJumpMultiplierValue = value; }
    }
    public float MaxDashMultiplierValue
    {
        get { return maxDashMultiplierValue; }
        set { maxDashMultiplierValue = value; }
    }

    public float JumpMultiplier
    {
        get { return jumpMultiplier; }
        set { jumpMultiplier = value; }
    }

    public float ResetJumpMultiplier
    {
        get { return resetJumpMultiplier; }
        set { resetJumpMultiplier = value; }
    }

    public float ResetDashMultiplier
    {
        get { return resetDashMultiplier; }
        set { resetDashMultiplier = value; }
    }

    public float DashMultiplier
    {
        get { return dashMultiplier; }
        set { dashMultiplier = value; }
    }

    public float SlowMoMultiplier
    {
        get { return slowMoMultiplier; }
        private set { slowMoMultiplier = value; }
    }

    public float DashTick
    {
        get { return dashTick; }
        set { dashTick = value; }
    }

    public float MinTime
    {
        get { return minTime; }
        set { minTime = value; }
    }

}
