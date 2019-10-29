using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Config/PlayerAttack Config")]
public class PlayerAttackConfig : ScriptableObject
{

    public BoxCollider2D attackBox;
    public float resetTime;

}
