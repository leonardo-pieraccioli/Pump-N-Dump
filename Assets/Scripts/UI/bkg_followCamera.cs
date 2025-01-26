using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bkg_followCamera : MonoBehaviour
{
    [SerializeField] private Transform t_camera;
    public float snap;

    // Update is called once per frame

    void Update()
    {
        Vector3 pos = new Vector3(Mathf.Round(t_camera.position.x/snap)*snap,Mathf.Round(t_camera.position.y/snap)*snap, 0.2f);
        transform.position = pos;
    }
}
