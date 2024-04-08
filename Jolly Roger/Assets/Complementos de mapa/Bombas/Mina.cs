using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int damageAmount = 200; // Quantidade de dano que a mina causa

    // M�todo chamado quando um objeto entra na �rea de colis�o da mina
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barco"))
        {
          // Verifica se o objeto que entrou na �rea de colis�o tem o script PlayerHealth
          PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

          // Se o objeto tiver o script PlayerHealth
          if (playerHealth != null)
          {
            // Reduz a sa�de do jogador pelo valor de dano da mina
            playerHealth.TakeDamage(damageAmount);
            Destroy(gameObject);
          }
        }
        if (other.CompareTag("Bomba"))
        {
            Destroy(gameObject);
        }
    }
}
