using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] static public float obstacleSpeed = 2.0f;
    private Pointer _pointer;

    void Start()
    {
        _pointer = FindObjectOfType<Pointer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(obstacleSpeed * (Vector2.left + Vector2.down).normalized * Time.deltaTime);
        if(transform.position.x < _pointer.transform.position.x - 15)
        {
            Destroy(gameObject);
        }
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