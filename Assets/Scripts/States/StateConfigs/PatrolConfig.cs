using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Config/Patrol Config")]
public class PatrolConfig : ScriptableObject
{
    public float patrolMovementSpeed;
    public float patrolRange;
}
