using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] public float _speed = 2.0f;
    [SerializeField] public float _angle = 45.0f;
    public Vector2 _direction;
    void Start()
    {
        _direction = Quaternion.Euler(0, 0, _angle) * Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Quaternion.Euler(0, 0, _angle) * Vector2.right; 
        if(Input.GetKey(KeyCode.Space))
            _direction = Quaternion.Euler(0, 0, -_angle) * Vector2.right;

        transform.Translate(_speed * _direction * Time.deltaTime);
    }
}
