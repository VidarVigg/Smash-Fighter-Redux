using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AiState
{

    #region Fields

    [SerializeField]
    private PatrolConfig patrolConfig = null;

    [SerializeField]
    private PatrolData patrolData = null;

    [SerializeField]
    private PatrolController patrolController = null;

    private EnemyMaster enemy;
    public float tick;


    #endregion

    public PatrolState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        Initialize();
    }

    public void Initialize()
    {
        patrolController = new PatrolController(this, patrolConfig, patrolData);
        //SetRandomDirection(GetRandomDirection());
    }

    public override void StateUpdate()
    {
        tick += Time.deltaTime;
        if (tick >= Random.Range(2, 4))
        {

        }

        RaycastHit2D[] test = enemy.GetWallCollisionArray();

        for (int i = 0; i < test.Length; i++)
        {
            if (test[i].collider != null)
            {
                SetRandomDirection(CalculateDirection(test[i].point));
            }
        }

        if ((enemy.transform.position - enemy.GetTarget()).sqrMagnitude < 20)
        {
            enemy.UpdateCurrentState(EnemyAIStates.Hunting);
        }

    }
    public Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
    }
    public void SetRandomDirection(Vector2 rand)
    {
        enemy.GetComponent<Rigidbody2D>().velocity = rand;
    }
    public Vector2 CalculateDirection(Vector2 hitPoint)
    {
        Debug.Log("Test");
        Vector2 dir = (Vector2)enemy.transform.position-hitPoint;
        dir = (Quaternion.AngleAxis(Random.Range(-180, 180), enemy.transform.position) * dir) * 10;
        return dir;
    }
}
