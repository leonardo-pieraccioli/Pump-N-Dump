using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private lr_LineController line;
    [SerializeField] public float _speed = 2.0f;
    [SerializeField] public float _angle = -45.0f;
    [SerializeField] private AudioClip _clickSound;
    public float _currentAngle = 0.0f;
    public Vector2 _direction;
    public SpriteRenderer sr;
    public bool _hasCollided = false;
    void Start()
    {
        _direction = Quaternion.Euler(0, 0, _angle) * Vector2.right;
        _currentAngle = _angle;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float previousAngle = _currentAngle;

         _currentAngle = _angle;
        if(Input.GetKey(KeyCode.Space) && !_hasCollided)
        {
            _currentAngle *= -1;
            
        }

        if (previousAngle > 0 && _currentAngle < 0)
        {
            line.AddPoint();
            AudioManager.Instance.PlaySound(_clickSound, .7f);
        }
        if (previousAngle < 0 && _currentAngle > 0)
        {
            AudioManager.Instance.PlaySound(_clickSound, 1.0f);
            line.AddPoint();
        }

        sr.transform.rotation = Quaternion.Euler(0, 0, -90 + _currentAngle);
        _direction = Quaternion.Euler(0, 0, _currentAngle) * Vector2.right;
        transform.Translate(_speed * _direction.normalized * Time.deltaTime);
    }

    public void ObstacleCollision()
    {
        if (_hasCollided) return;
        _hasCollided = true;
        StartCoroutine(ResetPointer());
    }

    IEnumerator ResetPointer()
    {
        float malusTimer = Random.Range(.3f, .6f);
        yield return new WaitForSeconds(malusTimer);
        _hasCollided = false;
    }
}
