using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int damageAmount = 200; // Quantidade de dano que a mina causa

    // Método chamado quando um objeto entra na área de colisão da mina
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na área de colisão tem o script PlayerHealth
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        // Se o objeto tiver o script PlayerHealth
        if (playerHealth != null)
        {
            // Reduz a saúde do jogador pelo valor de dano da mina
            playerHealth.TakeDamage(damageAmount);
        }

        // Desativa a mina após causar dano, independentemente do objeto que colidiu
        gameObject.SetActive(false);
    }
}
