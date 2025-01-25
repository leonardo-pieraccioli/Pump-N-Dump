using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvestorTrust : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Obstacle.obstacleSpeed * (Vector2.left + Vector2.down).normalized * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InvestorTrustSlider.UpdateValue(10);
            Destroy(gameObject);
        }
    }
}
