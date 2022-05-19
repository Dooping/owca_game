using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornSpawner : MonoBehaviour
{
    public GameObject unicorn;
    public float timeBetweenSpawn = 10;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [SerializeField]
    private Value lives;
    [SerializeField]
    private Value difficulty;

    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (lives.value != 0 && difficulty.value > 7 && Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(unicorn, transform.position + new Vector3(randomX, randomY, -2), transform.rotation);
    }
}
