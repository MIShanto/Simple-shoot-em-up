using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody2D rb;
    public float bulletSpeed;
    private void Awake()
    {
        gameManager = GameManager.instance;

        TryGetComponent(out rb);
    }
    public void Shoot()
    {
        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            gameManager.poolManager.ReturnObjToPool(gameObject);
        }
    }
}
