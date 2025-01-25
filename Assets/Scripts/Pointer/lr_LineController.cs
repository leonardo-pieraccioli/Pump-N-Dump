using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lr_LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    [SerializeField] GameObject _point_prefab;
    [SerializeField] GameObject _pointer;

    private Transform _new_point;

    // Start is called before the first frame update
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        
    }

    public void SetUpLine(Transform[] points){
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update(){
        lr.SetPosition(lr.positionCount - 1, _pointer.transform.position);
    }

    public void AddPoint(){
        _new_point = Instantiate(_point_prefab, _pointer.transform.position, Quaternion.identity).transform;
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 2, _new_point.position);
        lr.SetPosition(lr.positionCount - 1, _pointer.transform.position);
    }
}
