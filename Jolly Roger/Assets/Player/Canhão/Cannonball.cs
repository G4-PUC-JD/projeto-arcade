using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cannonball : MonoBehaviour
{
    public float speed = 30f; // Velocidade da bola de canh�o
    public int damage = 50; // Dano causado pela bola de canh�o
    public int tempoDesaparecer = 3;

    // M�todo chamado quando a bola de canh�o � instanciada
    void Start()
    {
        // Aplica uma for�a para frente para mover a bola de canh�o
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        // Destroi a bola de canh�o ap�s um certo tempo para evitar vazamentos de mem�ria
        Destroy(gameObject, tempoDesaparecer);
    }

    // M�todo chamado quando a bola de canh�o colide com outro objeto
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigos"))
        {
          // Verifica se o objeto que entrou na �rea de colis�o tem o script PlayerHealth
          VidaInimigos vidaInimigos = other.GetComponent<VidaInimigos>();

          // Se o objeto tiver o script PlayerHealth
          if (vidaInimigos != null)
          {
            // Reduz a sa�de do jogador pelo valor de dano da mina
            vidaInimigos.TakeDamage(damage);
            Destroy(gameObject);
          }
        }
     Destroy(gameObject);
    
    }
}