using UnityEngine;
using System;

[Serializable]
public class InputConfig 
{

    [SerializeField] private float maxMultiplierValue;
    [SerializeField] private float multiplier ;
    [SerializeField] private float reset;

    public float MaxMultiplierValue
    {
        get { return maxMultiplierValue; }
        set { maxMultiplierValue = value; }
    }

    public float Multiplier
    {
        get { return multiplier; }
        set { multiplier = value; }
    }

    public float Reset
    {
        get { return reset; }
        set { reset = value; }
    }

}
