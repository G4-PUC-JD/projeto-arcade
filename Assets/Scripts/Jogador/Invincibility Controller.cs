using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private int invincibilityPointCount = 0; // Contagem de pontos de invencibilidade
    private bool isInvincible = false; // Indica se o jogador está atualmente invencível
    private float invincibilityDuration = 5f; // Duração da invencibilidade em segundos

    // Método para coletar um ponto de invencibilidade
    public void CollectInvincibilityPoint()
    {
        invincibilityPointCount++; // Incrementa a contagem de pontos
    }

    // Método para usar um ponto de invencibilidade
    public bool UseInvincibilityPoint()
    {
        // Verifica se há pontos de invencibilidade disponíveis para uso
        if (invincibilityPointCount > 0)
        {
            invincibilityPointCount--; // Decrementa a contagem de pontos
            ActivateInvincibility(); // Ativa a invencibilidade
            return true; // Indica que um ponto foi usado com sucesso
        }
        else
        {
            return false; // Indica que não há pontos disponíveis para uso
        }
    }

    // Método para ativar a invencibilidade
    private void ActivateInvincibility()
    {
        isInvincible = true; // Ativa o estado de invencibilidade
        Debug.Log("Invencibilidade ativada!"); // Adiciona um Debug.Log para indicar que a invencibilidade foi ativada
        Invoke("DeactivateInvincibility", invincibilityDuration); // Inicia a contagem regressiva para desativar a invencibilidade após a duração definida
    }

    // Método para desativar a invencibilidade após a duração definida
    private void DeactivateInvincibility()
    {
        isInvincible = false; // Desativa o estado de invencibilidade
    }

    // Método para verificar se o jogador está invencível
    public bool IsInvincible()
    {
        return isInvincible;
    }
}
