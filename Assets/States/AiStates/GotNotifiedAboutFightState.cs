using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotNotifiedAboutFightState : State
{
    private EnemyMaster enemy;
    private EnemyMaster caller;
    private Vector2 positionOfCaller;
    private float offset;
    private bool initialMove;

    public GotNotifiedAboutFightState(Character character, EnemyMaster caller) : base(character)
    {
        this.enemy = (EnemyMaster)character;
        character.stateText.text = this.ToString();
        this.caller = caller;
    }

    public override void EnterState()
    {
        enemy.IgnoreNeighbours();
        Debug.Log(enemy.gameObject.name + " Entered " + this.ToString());
        initialMove = false;

    }

    public override void Update()
    {
        positionOfCaller = caller.GetComponent<Transform>().position;
        enemy.movementController.Move((positionOfCaller - (Vector2)enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);
        if ((positionOfCaller - (Vector2)enemy.transform.position).sqrMagnitude < enemy.NeighbourConfig.minDistance)
        {
            enemy.movementController.Move(Vector3.zero);

            //if (!initialMove)
            //{
            //    initialMove = true;
            //}


            RaycastHit2D[] hits = enemy.GetWallCollisionArray();

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[0].collider != null)
                {
                    Debug.Log(hits[0].collider);
                    enemy.transform.position = Vector3.Lerp(enemy.transform.position, positionOfCaller + new Vector2(-0.5f, 0), 0.1f);
                }
                if (hits[1].collider != null)
                {
                    Debug.Log(hits[1].collider);
                    enemy.transform.position = Vector3.Lerp(enemy.transform.position, positionOfCaller + new Vector2(0.5f, 0), 0.1f);

                }
                if (hits[2].collider != null)
                {
                    Debug.Log(hits[2].collider);
                    enemy.transform.position = Vector3.Lerp(enemy.transform.position, positionOfCaller + new Vector2(0, -0.5f), 0.1f);

                }
                if (hits[3].collider != null)
                {
                    Debug.Log(hits[3].collider);
                    enemy.transform.position = Vector3.Lerp(enemy.transform.position, positionOfCaller + new Vector2(0, 0.5f), 0.1f);

                }
                if (hits[i].collider == null)
                {
                    enemy.transform.position = Vector3.Lerp(enemy.transform.position, positionOfCaller + new Vector2(0.5f, 0), 0.1f);

                }
                //enemy.transform.position = Vector3.Lerp(enemy.transform.position, positionOfCaller + new Vector2(0, 0.5f), 0.1f);

            }
            //enemy.RemoveNeighbour(enemy);
            //enemy.UpdateCurrentState(new HuntState(character, true));
        }
    }
    public override void ExitState()
    {

    }
    public override void Handle(State state)
    {

    }

}
