using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    public int invincibilityPointCount = 0; // Contagem de pontos de invencibilidade
    private bool isInvincible = false; // Indica se o jogador est� atualmente invenc�vel
    public float invincibilityDuration = 5f; // Dura��o da invencibilidade em segundos

    // M�todo para coletar um ponto de invencibilidade
    public void CollectInvincibilityPoint()
    {
        invincibilityPointCount++; // Incrementa a contagem de pontos
    }

    // M�todo para usar um ponto de invencibilidade
    public bool UseInvincibilityPoint()
    {
        // Verifica se h� pontos de invencibilidade dispon�veis para uso
        if (invincibilityPointCount > 0)
        {
            invincibilityPointCount--; // Decrementa a contagem de pontos
            ActivateInvincibility(); // Ativa a invencibilidade
            return true; // Indica que um ponto foi usado com sucesso
        }
        else
        {
            return false; // Indica que n�o h� pontos dispon�veis para uso
        }
    }

    // M�todo para ativar a invencibilidade
    private void ActivateInvincibility()
    {
        isInvincible = true; // Ativa o estado de invencibilidade
        Debug.Log("Invencibilidade ativada!"); // Adiciona um Debug.Log para indicar que a invencibilidade foi ativada
        Invoke("DeactivateInvincibility", invincibilityDuration); // Inicia a contagem regressiva para desativar a invencibilidade ap�s a dura��o definida
    }

    // M�todo para desativar a invencibilidade ap�s a dura��o definida
    private void DeactivateInvincibility()
    {
        isInvincible = false; // Desativa o estado de invencibilidade
    }

    // M�todo para verificar se o jogador est� invenc�vel
    public bool IsInvincible()
    {
        return isInvincible;
    }
}
