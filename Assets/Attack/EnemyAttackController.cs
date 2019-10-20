using UnityEngine;

public class EnemyAttackController : AttackController
{

    [SerializeField]
    private BoxCollider2D attackCollider;

    public override void Attack()
    {
        Debug.Log("Enemy Attacked");
        attackCollider.enabled = true;
    }
}