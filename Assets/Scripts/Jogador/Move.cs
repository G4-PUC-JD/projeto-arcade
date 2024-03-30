using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    public Transform alvo;
    // Start is called before the first frame update
    void Start()
    {
        alvo = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        alvo.Rotate(Vector3.up, 1);
        
    }
}
