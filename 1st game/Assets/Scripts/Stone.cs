using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    GameManager gameManager;

    Rigidbody2D rb;

    public float stoneSpeed;

    private void Awake()
    {
        gameManager = GameManager.instance;

        TryGetComponent(out rb);
    }
    public void Drop()
    {
        rb.AddForce(Vector2.down * stoneSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            gameManager.poolManager.ReturnObjToPool(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            gameManager.poolManager.ReturnObjToPool(gameObject);

            gameManager.isGameOver = true;
            gameManager.HUDManager.UpdateGameOverPanel(true);
        }
    }
}
