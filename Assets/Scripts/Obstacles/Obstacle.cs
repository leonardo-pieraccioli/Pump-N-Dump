using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] static public float obstacleSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(obstacleSpeed * (Vector2.left + Vector2.down).normalized * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<Pointer>().ObstacleCollision();
            Destroy(gameObject);
        }
    }
}