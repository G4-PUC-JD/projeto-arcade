using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circulo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform c;
    public float r;
    float t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //x = c  r * cos(t)
        //y = c + r * sen(t)
        t += Time.deltaTime;
        float x = c.position.x + r * Mathf.Cos(t);
        float y = c.position.y + r * Mathf.Sin(t);
        transform.position = new Vector3(x, y, 0);
        
    }
}
