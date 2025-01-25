using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _spawnRate = 2.0f;
    [SerializeField] private float _spawnRateMax = 3.0f;
    [SerializeField] private float _spawnRateMin = 1.0f;
    private float _timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _spawnRate)
        {
            Instantiate(_obstaclePrefab, CalculateSpawnPosition(), Quaternion.identity);
            _timer = 0.0f;
            _spawnRate = Random.Range(_spawnRateMax, _spawnRateMin);
        }
    }

    Vector3 CalculateSpawnPosition()
    {
        Vector3 playerPosition = _pointer.transform.position;
        Vector3 playerDirection = _pointer._direction;
        Vector3 spawnPosition = playerPosition + playerDirection * 10.0f;
        return spawnPosition + new Vector3(0, 0, -1);
    }
}
