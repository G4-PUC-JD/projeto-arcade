using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // O m�ximo de pontos de vida que o jogador pode ter
    private int currentHealth; // A quantidade atual de pontos de vida do jogador
    private InvincibilityController invincibilityController; // Refer�ncia para o script InvincibilityController
    private bool isInvincibilityActive = false; // Indica se a invencibilidade est� ativa
    private float invincibilityDuration = 5f; // Dura��o da invencibilidade em segundos

    void Start()
    {
        // Define a quantidade inicial de pontos de vida para o valor m�ximo
        currentHealth = maxHealth;

        // Obt�m o componente InvincibilityController do jogador
        invincibilityController = GetComponent<InvincibilityController>();
    }

    // M�todo para reduzir os pontos de vida do jogador
    public void TakeDamage(int damageAmount)
    {
        // Verifica se a invencibilidade est� ativa
        if (isInvincibilityActive)
        {
            return; // Se estiver ativa, n�o causa dano
        }

        // Reduz os pontos de vida do jogador
        currentHealth -= damageAmount;

        // Verifica se os pontos de vida chegaram a zero ou menos
        if (currentHealth <= 0)
        {
            // Se sim, chama o m�todo para tratar a morte do jogador
            Die();
        }
    }

    // M�todo para aumentar os pontos de vida do jogador
    public void Heal(int healAmount)
    {
        // Aumenta os pontos de vida do jogador
        currentHealth += healAmount;

        // Garante que os pontos de vida n�o ultrapassem o m�ximo
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // M�todo para tratar a morte do jogador
    void Die()
    {
        // Desativa o GameObject do jogador para que ele desapare�a da cena
        gameObject.SetActive(false);
    }

    // M�todo chamado no update para verificar o input do jogador
    private void Update()
    {
        // Verifica se o jogador pressionou o bot�o para ativar a invencibilidade
        if (Input.GetButtonDown("Fire3") && invincibilityController.UseInvincibilityPoint())
        {
            // Ativa a invencibilidade por um per�odo de tempo
            ActivateInvincibility();
        }
    }

    // M�todo para ativar a invencibilidade por um per�odo de tempo
    private void ActivateInvincibility()
    {
        isInvincibilityActive = true; // Ativa a invencibilidade
        Invoke("DeactivateInvincibility", invincibilityDuration); // Desativa a invencibilidade ap�s a dura��o definida
    }

    // M�todo para desativar a invencibilidade ap�s a dura��o definida
    private void DeactivateInvincibility()
    {
        isInvincibilityActive = false; // Desativa a invencibilidade
    }
}
