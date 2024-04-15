using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // O máximo de pontos de vida que o jogador pode ter
    private int currentHealth; // A quantidade atual de pontos de vida do jogador
    private InvincibilityController invincibilityController; // Referência para o script InvincibilityController
    private bool isInvincibilityActive = false; // Indica se a invencibilidade está ativa
    private float invincibilityDuration = 5f; // Duração da invencibilidade em segundos

    void Start()
    {
        // Define a quantidade inicial de pontos de vida para o valor máximo
        currentHealth = maxHealth;

        // Obtém o componente InvincibilityController do jogador
        invincibilityController = GetComponent<InvincibilityController>();
    }

    // Método para reduzir os pontos de vida do jogador
    public void TakeDamage(int damageAmount)
    {
        // Verifica se a invencibilidade está ativa
        if (isInvincibilityActive)
        {
            return; // Se estiver ativa, não causa dano
        }

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

    // Método chamado no update para verificar o input do jogador
    private void Update()
    {
        // Verifica se o jogador pressionou o botão para ativar a invencibilidade
        if (Input.GetButtonDown("Fire3") && invincibilityController.UseInvincibilityPoint())
        {
            // Ativa a invencibilidade por um período de tempo
            ActivateInvincibility();
        }
    }

    // Método para ativar a invencibilidade por um período de tempo
    private void ActivateInvincibility()
    {
        isInvincibilityActive = true; // Ativa a invencibilidade
        Invoke("DeactivateInvincibility", invincibilityDuration); // Desativa a invencibilidade após a duração definida
    }

    // Método para desativar a invencibilidade após a duração definida
    private void DeactivateInvincibility()
    {
        isInvincibilityActive = false; // Desativa a invencibilidade
    }
}
