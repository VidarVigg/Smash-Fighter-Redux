using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Config/Hunt Config")]
public class HuntConfig : ScriptableObject
{
    public float huntSpeed;
    public float minHuntRange;
    public float huntRange;
}
