using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float timeBetweenSpawn = 1;
    public float minX;
    public float maxX;
    public float y;

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
        float randomX = Random.Range(minX, maxX);
        GameObject instance = Instantiate(objectToSpawn, transform.position + new Vector3(randomX, y, -2), transform.rotation);
    }
}
