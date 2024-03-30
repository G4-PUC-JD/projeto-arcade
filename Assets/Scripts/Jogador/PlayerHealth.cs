using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // O máximo de pontos de vida que o jogador pode ter
    private int currentHealth; // A quantidade atual de pontos de vida do jogador

    void Start()
    {
        // Define a quantidade inicial de pontos de vida para o valor máximo
        currentHealth = maxHealth;
    }

    // Método para reduzir os pontos de vida do jogador
    public void TakeDamage(int damageAmount)
    {
        // Reduz os pontos de vida do jogador
        currentHealth -= damageAmount;

        // Verifica se os pontos de vida chegaram a zero ou menos
        if (currentHealth <= 0)
        {
            // Se sim, chama o método para tratar a morte do jogador
            Die();
        }
    }

    // Método para aumentar os pontos de vida do jogador
    public void Heal(int healAmount)
    {
        // Aumenta os pontos de vida do jogador
        currentHealth += healAmount;

        // Garante que os pontos de vida não ultrapassem o máximo
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // Método para tratar a morte do jogador
    void Die()
    {
        // Desativa o GameObject do jogador para que ele desapareça da cena
        gameObject.SetActive(false);
    }
}
