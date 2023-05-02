using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float bottomSpawnPoint, upSpawnPoint;
    public Vector3 spawnPoint;

    public GameObject stonePrefab, enemyPrefab;

    public float spawnIntervalMin, spawnIntervalMax;

    GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameManager.instance;

        spawnPoint = new Vector3(11f, 0, 0);
    }
    void SpawnStone()
    {
        if (gameManager.isGameOver)
            return;

        spawnPoint.y = Random.Range(bottomSpawnPoint, upSpawnPoint);

        var stoneObj = gameManager.poolManager.GetObjFromPool(stonePrefab);
        stoneObj.name = stonePrefab.name;
        stoneObj.transform.position = spawnPoint;

        stoneObj.TryGetComponent(out Obstacle stone);

        stone.Drop();
    }
    void SpawnEnemy()
    {
        if (gameManager.isGameOver)
            return;

        spawnPoint.y = Random.Range(bottomSpawnPoint, upSpawnPoint);

        var enemyObj = gameManager.poolManager.GetObjFromPool(enemyPrefab);
        enemyObj.name = enemyPrefab.name;
        enemyObj.transform.position = spawnPoint;
        /*
                enemyObj.TryGetComponent(out Enemy enemy);

                enemy.Drop();*/
    }
}
