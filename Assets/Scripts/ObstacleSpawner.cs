using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public List<GameObject> possibleObstacles;
    public List<GameObject> possibleSpecialObstacles;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private int obstacleCounter = 0;
    private List<GameObject> allPossibleObstacles;

    // Start is called before the first frame update
    void Start()
    {
        allPossibleObstacles = new List<GameObject>();
        allPossibleObstacles.AddRange(possibleObstacles);
        allPossibleObstacles.AddRange(possibleSpecialObstacles);
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

    void Spawn()
    {
        GameObject obstacle = SelectObstacle();

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        
        obstacleCounter++;
    }

    private GameObject SelectObstacle()
    {
        GameObject obstacle;
        if (obstacleCounter < 25 && Random.Range(0, 50) < obstacleCounter)
        {
            obstacle = possibleSpecialObstacles[Random.Range(0, possibleSpecialObstacles.Count)];
        }
        else if (obstacleCounter < 30)
        {
            obstacle = possibleObstacles[Random.Range(0, possibleObstacles.Count)];
        }
        else
        {
            obstacle = allPossibleObstacles[Random.Range(0, allPossibleObstacles.Count)];
        }

        return obstacle;
    }
}
