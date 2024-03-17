using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float forwardSpeed = 3f; // Velocidade que o barco se move pra frente
    float turnSpeed = 70f; // Velocidade que o barco vira

    // Update is called once per frame
    void Update()
    {
        // Pega o INput horizontal para virar
        float horizontalInput = Input.GetAxis("Horizontal");

        //Vira o barco pra direita ou esqureda baseado no input
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        // Pega o input para ir para frente ou tras
        float verticalInput = Input.GetAxis("Vertical");

        // Move o barco pra frente
        transform.Translate(Vector3.forward * verticalInput * forwardSpeed * Time.deltaTime);
    }
}