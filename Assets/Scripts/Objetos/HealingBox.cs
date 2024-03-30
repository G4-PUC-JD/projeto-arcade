using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBox : MonoBehaviour
{
    public int healingAmount = 100; // Quantidade de vida que a caixa de cura fornece

    // Método chamado quando um objeto entra na área de colisão da caixa de cura
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na área de colisão é o jogador
        if (other.CompareTag("Barco"))
        {
            // Obtém o script PlayerHealth do jogador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Se o script PlayerHealth existir no jogador
            if (playerHealth != null)
            {
                // Aumenta a saúde do jogador pelo valor de cura da caixa de cura
                playerHealth.Heal(healingAmount);

                // Desativa a caixa de cura após ser tocada pelo jogador
                Destroy(gameObject);
            }
        }
    }
}
