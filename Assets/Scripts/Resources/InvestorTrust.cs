using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvestorTrust : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    void Update()
    {
        transform.Translate(Obstacle.obstacleSpeed * (Vector2.left + Vector2.down).normalized * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InvestorTrustSlider.Instance.UpdateValue(10);
            AudioManager.Instance.PlaySound(_audioClip, 0.7f + InvestorTrustSlider.Instance.slider.value / 300);
            Destroy(gameObject);
        }
    }
}
