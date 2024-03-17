using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reta : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    [Range(0,1)] 
    public float t;
    public Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //v = p2.position - p1.position;
        //transform.position = p1.position + v * t ;
        transform.position = Vector3.Lerp(p1.position, p2.position, t);
    }
}
