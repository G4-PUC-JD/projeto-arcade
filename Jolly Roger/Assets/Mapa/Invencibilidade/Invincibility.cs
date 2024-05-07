using UnityEngine;

public class InvincibilityCollectible : MonoBehaviour
{
    // Método chamado quando um objeto entra na área de colisão do coletível de invencibilidade
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na área de colisão é o jogador
        if (other.CompareTag("Barco"))
        {
            // Obtém o componente InvincibilityController do jogador
            InvincibilityController invincibilityController = other.GetComponent<InvincibilityController>();

            // Se o componente InvincibilityController existir no jogador
            if (invincibilityController != null)
            {
                // Coleta o ponto de invencibilidade
                invincibilityController.CollectInvincibilityPoint();

                // Desativa o objeto que concedeu o ponto de invencibilidade
                gameObject.SetActive(false);
            }
        }
    }
}
