using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaInimigos : MonoBehaviour
{
    public int maxHealth = 100; // O m�ximo de pontos de vida que o jogador pode ter
    private int currentHealth; // A quantidade atual de pontos de vida do jogador
    void Start()
    {
        // Define a quantidade inicial de pontos de vida para o valor m�ximo
        currentHealth = maxHealth;
    }

    // M�todo para reduzir os pontos de vida do jogador
    public void TakeDamage(int damageAmount)
    {
        // Reduz os pontos de vida do jogador
        currentHealth -= damageAmount;

        // Verifica se os pontos de vida chegaram a zero ou menos
        if (currentHealth <= 0)
        {
            // Se sim, chama o m�todo para tratar a morte do jogador
            Die();
        }
    }
    // M�todo para tratar a morte do jogador
    void Die()
    {
        // Desativa o GameObject do jogador para que ele desapare�a da cena
        gameObject.SetActive(false);
    }
}
