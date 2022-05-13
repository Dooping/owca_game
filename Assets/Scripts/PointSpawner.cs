using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public List<GameObject> possiblePoints;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Spawn()
    {
        GameObject point = SelectPoint();

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(point, transform.position + new Vector3(randomX, randomY, -2), transform.rotation);
    }

    private GameObject SelectPoint()
    {
        return possiblePoints[Random.Range(0, possiblePoints.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }
}
