using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State Config/Dash Charge Config")]
public class DashChargeConfig: ScriptableObject
{
    public float chargeAmt;
    public float tick;
    public float reset;
    public float maxDashMultiplier;
    public float timeBeforeEnemyNotified;
}
