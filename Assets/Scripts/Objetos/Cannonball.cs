using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cannonball : MonoBehaviour
{
    public float speed = 30f; // Velocidade da bola de canhão
    public int damage = 50; // Dano causado pela bola de canhão

    // Método chamado quando a bola de canhão é instanciada
    void Start()
    {
        // Aplica uma força para frente para mover a bola de canhão
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        // Destroi a bola de canhão após um certo tempo para evitar vazamentos de memória
        Destroy(gameObject, 1f);
    }

    // Método chamado quando a bola de canhão colide com outro objeto
    void OnTriggerEnter(Collider other)
    {
        // Destroi a bola de canhão após colidir com outro objeto
        Destroy(gameObject);
    }
}