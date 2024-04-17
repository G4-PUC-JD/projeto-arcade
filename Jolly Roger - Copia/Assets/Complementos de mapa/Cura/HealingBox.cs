using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBox : MonoBehaviour
{
    public int healingAmount = 100; // Quantidade de vida que a caixa de cura fornece

    // M�todo chamado quando um objeto entra na �rea de colis�o da caixa de cura
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea de colis�o � o jogador
        if (other.CompareTag("Barco"))
        {
            // Obt�m o script PlayerHealth do jogador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Se o script PlayerHealth existir no jogador
            if (playerHealth != null)
            {
                // Aumenta a sa�de do jogador pelo valor de cura da caixa de cura
                playerHealth.Heal(healingAmount);

                // Desativa a caixa de cura ap�s ser tocada pelo jogador
                Destroy(gameObject);
            }
        }
    }
}