using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmoState : State
{

    EnemyMaster enemy;
    RaycastHit2D floorHit;
    Vector2 floor;
    bool right;
    bool left;
    GameObject chosenBullet;
    private bool bulletChosen;

    public CollectAmmoState(Character character) : base(character)
    {
        this.enemy = (EnemyMaster)character;
    }

    public override void EnterState()
    {
        character.stateText.text = this.ToString();
        bulletChosen = false;
        //Debug.Log(AmmoSpawner.INSTANCE.index - 1);
    }

    public override void Update()
    {
        if (!bulletChosen)
        {
            CheckForBullets();
            
        }
        if (chosenBullet)
        {
            //enemy.transform.position = Vector3.Lerp(enemy.transform.position, (Vector2)chosenBullet.transform.position, 0.02f);
           enemy.movementController.Move((chosenBullet.transform.position - enemy.transform.position).normalized * enemy.HuntConfig.huntSpeed);

            if ((enemy.transform.position - chosenBullet.transform.position).sqrMagnitude < 10 * Time.deltaTime)
            {
                enemy.transform.position = chosenBullet.transform.position;
                enemy.IncreaseAmmo();
                AmmoSpawner.INSTANCE.DeleteBullet(chosenBullet);
                chosenBullet = null;
                enemy.UpdateCurrentState(new PatrolState(character));

            }
        }
        else
        {
           
                enemy.UpdateCurrentState(new PatrolState(character));
        }

    }

    public override void ExitState()
    {

    }

    public override void Handle(State state)
    {

    }

    public void CheckForBullets()
    {
        for (int i = 0; i < AmmoSpawner.INSTANCE.spawnedBullets.Count; i++)
        {
            if (AmmoSpawner.INSTANCE.spawnedBullets[i] != null)
            {
                chosenBullet = AmmoSpawner.INSTANCE.spawnedBullets[i];
                bulletChosen = true;
            }
            else
            {
                enemy.UpdateCurrentState(new PatrolState(character));
            }
        }
    }

}
