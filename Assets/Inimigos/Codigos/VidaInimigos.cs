using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaInimigos : MonoBehaviour
{
    public int maxHealth = 100; // O m�ximo de pontos de vida que o jogador pode ter
    public int currentHealth; // A quantidade atual de pontos de vida do jogador
    void Start()
    {
        // Define a quantidade inicial de pontos de vida para o valor m�ximo
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (currentHealth <= 0)
        {   
            ScoreManager.instance.AddPoint();
            // Se sim, chama o m�todo para tratar a morte do jogador
            Destroy(gameObject);
        }
    }
    // M�todo para reduzir os pontos de vida do jogador
    public void TakeDamage(int damageAmount)
    {
        // Reduz os pontos de vida do jogador
        currentHealth -= damageAmount;
    }
    // M�todo para tratar a morte do jogador
}