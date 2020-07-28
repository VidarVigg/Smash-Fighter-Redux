using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    float tick;
    private GameObject bulletClone;

    public List<GameObject> spawnedBullets = new List<GameObject>();

    public int index = 0;

    [SerializeField]
    private float spawnRate;


    [SerializeField]
    private int maxAmmoAllowed;


    public static AmmoSpawner INSTANCE;


    private void Awake()
    {
        INSTANCE = this;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if ((tick += Time.deltaTime) >= spawnRate)
        {
            tick -= spawnRate;

            if (index < maxAmmoAllowed)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        bulletClone = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        bulletClone.transform.position = new Vector2(Random.Range(-15f, 15f), -14.8f);
        spawnedBullets.Add(bulletClone);
        index++;
    }

    public void DeleteBullet(GameObject bullet)
    {
        spawnedBullets.Remove(bullet);
        Destroy(bullet);
        if (index > 0)
        {
            index--;

        }
    }

}
