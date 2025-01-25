using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 _speed = new (1f, 0f, 0f);
    private SpriteRenderer sr;
    [SerializeField] private lr_LineController line;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            _speed += new Vector3(0f, 1f, 0f); //versione prova
            line.AddPoint();
        }
        transform.position += Time.deltaTime * _speed;
    }
}
