using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 3f; // Mesafe
    public float moveSpeed = 2f;    // Hýz

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; // Ýlk konumu kaydet
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Saða hareket biter
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Sola hareket biter
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
