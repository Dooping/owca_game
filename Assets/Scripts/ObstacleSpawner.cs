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
    public float maxTimeBetweenSpawn = 3.5f;
    public float minTimeBetweenSpawn = 1.5f;
    private float deltaTimeBetweenExtremes;
    private double spawnTime;
    private int obstacleCounter = 0;
    private List<GameObject> allPossibleObstacles;

    [SerializeField]
    private Value lives;
    [SerializeField]
    private Value difficulty;

    // Start is called before the first frame update
    void Start()
    {
        allPossibleObstacles = new List<GameObject>();
        allPossibleObstacles.AddRange(possibleObstacles);
        allPossibleObstacles.AddRange(possibleSpecialObstacles);
        difficulty.value = 0;
        deltaTimeBetweenExtremes = maxTimeBetweenSpawn - minTimeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives.value != 0 && Time.timeAsDouble > spawnTime)
        {
            Spawn();
            if (difficulty.value < 100)
            {
                difficulty.value++;
            }
            CalculateNewSpawnTime();
        }
    }

    private void CalculateNewSpawnTime()
    {
        spawnTime = Time.timeAsDouble + deltaTimeBetweenExtremes - (deltaTimeBetweenExtremes * difficulty.value / 100) + minTimeBetweenSpawn;
    }

    void Spawn()
    {
        GameObject obstacle = SelectObstacle();

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, -2), transform.rotation);
        
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
