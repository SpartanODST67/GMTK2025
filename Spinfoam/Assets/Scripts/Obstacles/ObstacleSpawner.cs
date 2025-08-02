using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Vector2 timeRange;
    [SerializeField] float timeDecrease = .5f;
    float currentTimeBetweenSpawns;
    int currentLevel = 1;
    [SerializeField] float timeBetweenLevels = 15f;
    [SerializeField] List<Obstacle> obstacles;
    [SerializeField] int maxObstacles = 10;
    int numObstacles = 0;
    [SerializeField] Vector2 spawnArea;
    public static ObstacleSpawner instance {  get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        currentTimeBetweenSpawns = timeRange.x;
        Spawn();
        Invoke(nameof(LevelUp), timeBetweenLevels);
    }

    private void Spawn()
    {
        if (numObstacles < maxObstacles)
        {
            numObstacles++;

            Obstacle newObstacle = obstacles[Random.Range(0, Mathf.Min(obstacles.Count, currentLevel))];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), Random.Range(-spawnArea.y / 2, spawnArea.y / 2));
            GameObject createdObstacle = Instantiate(newObstacle.gameObject, spawnPosition, Quaternion.identity);

            if(createdObstacle.TryGetComponent(out Obstacle obstacleScript))
            {
                obstacleScript.Spawn();
            } else
            {
                Debug.Log($"Failed to get obstacle script from {createdObstacle.name}");
                Destroy(createdObstacle);
                numObstacles--;
            }
        }
        Invoke(nameof(Spawn), currentTimeBetweenSpawns);
        currentTimeBetweenSpawns -= timeDecrease;
        if (currentTimeBetweenSpawns < timeRange.y) currentTimeBetweenSpawns = timeRange.y;
    }

    private void LevelUp()
    {
        if (currentLevel == obstacles.Count) return;
        currentLevel++;
        Invoke(nameof(LevelUp), timeBetweenLevels);
    }

    public void RemoveObstacle()
    {
        numObstacles--;
        if (numObstacles < 0) numObstacles = 0;
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }

}
