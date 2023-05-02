using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float leftSpawnPoint, rightSpawnPoint;
    public Vector3 spawnPoint;

    public GameObject collectablePrefab, enemyPrefab;

    public float spawnIntervalMin, spawnIntervalMax;

    GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameManager.instance;

        spawnPoint = new Vector3(0, 5.5f, 0);
    }
    void SpawnCollectables()
    {
        if (gameManager.isGameOver)
            return;

        spawnPoint.x = Random.Range(leftSpawnPoint, rightSpawnPoint);

        var collectablesObj = gameManager.poolManager.GetObjFromPool(collectablePrefab);
        collectablesObj.name = collectablePrefab.name;
        collectablesObj.transform.position = spawnPoint;

        collectablesObj.TryGetComponent(out Collcetables Collectable);

        Collectable.Drop();
    }
    void SpawnEnemy()
    {
        if (gameManager.isGameOver)
            return;

        spawnPoint.x = Random.Range(leftSpawnPoint, rightSpawnPoint);

        var obstacleObj = gameManager.poolManager.GetObjFromPool(enemyPrefab);
        obstacleObj.name = enemyPrefab.name;
        obstacleObj.transform.position = spawnPoint;

        obstacleObj.TryGetComponent(out Obstacle obstacle);

        obstacle.Drop();
    }
}
