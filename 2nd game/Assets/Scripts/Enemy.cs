using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    public float minXLimit, maxXLimit, minYLimit, maxYLimit;
    Vector2 movePos;
    public float moveSpeed;
    private void Awake()
    {
        gameManager = GameManager.instance;

        UpdatePos();
    }
    private void Update()
    {
        if (gameManager.isGameOver)
            return;

        if (Vector2.Distance(transform.position, movePos) <= 0.1f)
            UpdatePos();

    }
    private void FixedUpdate()
    {
        if (gameManager.isGameOver)
            return;

        Move();
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos, moveSpeed * Time.deltaTime);
    }
    void UpdatePos()
    {
        movePos = new Vector2(Random.Range(minXLimit, maxXLimit), Random.Range(minYLimit, maxYLimit));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            gameManager.poolManager.ReturnObjToPool(gameObject);
        }
        if (collision.CompareTag("Bullet"))
        {
            gameManager.poolManager.ReturnObjToPool(gameObject);
            gameManager.enemyDestroyedCounter++;
            gameManager.HUDManager.UpdateCounter(gameManager.enemyDestroyedCounter.ToString());
        }
        if (collision.CompareTag("Player"))
        {
            gameManager.poolManager.ReturnObjToPool(gameObject);

            gameManager.isGameOver = true;
            gameManager.HUDManager.UpdateGameOverPanel(true);
        }
    }
}
