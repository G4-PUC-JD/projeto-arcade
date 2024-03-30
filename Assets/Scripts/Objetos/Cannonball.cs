using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cannonball : MonoBehaviour
{
    public float speed = 30f; // Velocidade da bola de canh�o
    public int damage = 50; // Dano causado pela bola de canh�o

    // M�todo chamado quando a bola de canh�o � instanciada
    void Start()
    {
        // Aplica uma for�a para frente para mover a bola de canh�o
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        // Destroi a bola de canh�o ap�s um certo tempo para evitar vazamentos de mem�ria
        Destroy(gameObject, 1f);
    }

    // M�todo chamado quando a bola de canh�o colide com outro objeto
    void OnTriggerEnter(Collider other)
    {
        // Destroi a bola de canh�o ap�s colidir com outro objeto
        Destroy(gameObject);
    }
}