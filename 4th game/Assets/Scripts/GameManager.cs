using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public SpawnManager spawnManager;
    public PoolManager poolManager;
    public HUDManager HUDManager;

    public bool isGameOver = false;

    public int counter;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void OnGameStart()
    {
        spawnManager.InvokeRepeating("SpawnCollectables", 0f, Random.Range(spawnManager.spawnIntervalMin, spawnManager.spawnIntervalMax));
        spawnManager.InvokeRepeating("SpawnEnemy", 0f, Random.Range(spawnManager.spawnIntervalMin, spawnManager.spawnIntervalMax));
    }
    public void Replay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
