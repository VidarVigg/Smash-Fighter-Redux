using UnityEngine;

public class EnemyAttackController : AttackController
{

    [SerializeField]
    private BoxCollider2D attackCollider;

    public override void Attack()
    {
        attackCollider.enabled = true;
    }
}