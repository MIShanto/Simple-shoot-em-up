using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float leftSpawnPoint, rightSpawnPoint;
    public Vector3 spawnPoint;

    public GameObject stonePrefab, enemyPrefab;

    public float spawnIntervalMin, spawnIntervalMax;

    GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameManager.instance;

        spawnPoint = new Vector3(0, 4.5f, 0);
    }
    void SpawnStone()
    {
        if (gameManager.isGameOver)
            return;

        spawnPoint.x = Random.Range(leftSpawnPoint, rightSpawnPoint);

        var stoneObj = gameManager.poolManager.GetObjFromPool(stonePrefab);
        stoneObj.name = stonePrefab.name;
        stoneObj.transform.position = spawnPoint;

        stoneObj.TryGetComponent(out Stone stone);

        stone.Drop();
    }
    void SpawnEnemy()
    {
        if (gameManager.isGameOver)
            return;

        spawnPoint.x = Random.Range(leftSpawnPoint, rightSpawnPoint);

        var enemyObj = gameManager.poolManager.GetObjFromPool(enemyPrefab);
        enemyObj.name = enemyPrefab.name;
        enemyObj.transform.position = spawnPoint;
        /*
                enemyObj.TryGetComponent(out Enemy enemy);

                enemy.Drop();*/
    }
}
