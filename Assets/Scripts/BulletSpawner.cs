using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float timeBetweenSpawn = 2;
    
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        Instantiate(bullet, gameObject.transform.position, transform.rotation);
    }
}
