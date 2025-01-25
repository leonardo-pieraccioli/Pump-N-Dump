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
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    public void AddPoint(){
        _new_point = Instantiate(_point_prefab, _pointer.transform.position, Quaternion.identity).transform;
        //rimuovi elemento in coda
        points = points.Take(points.Length - 1).ToArray();
        points = points.Append(_new_point).ToArray();
        points = points.Append(_pointer.transform).ToArray();
        lr.positionCount = points.Length;
    }
}
