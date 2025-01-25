using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_PointMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 _speed = new (1f, 0f, 0f);
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            _speed = Vector3.zero;
            sr.enabled = true;
        }
        transform.position += Time.deltaTime * _speed;
    }
}
