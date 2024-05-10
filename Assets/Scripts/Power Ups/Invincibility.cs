using UnityEngine;

public class InvincibilityCollectible : MonoBehaviour
{
    public AudioClip collectSound; // Som a ser reproduzido ao coletar o coletível de invencibilidade
    public float delayBeforeDisappear = 0.5f; // Tempo de espera antes do objeto desaparecer

    private AudioSource audioSource; // Componente de áudio para reproduzir o som

    void Start()
    {
        // Adiciona um componente de áudio ao objeto coletível
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de áudio
        audioSource.clip = collectSound;
    }

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

                // Reproduz o som de coleta
                audioSource.Play();

                // Desativa o objeto que concedeu o ponto de invencibilidade após um pequeno atraso
                // Para garantir que o som seja reproduzido antes que o objeto seja desativado
                Invoke("DeactivateCollectible", delayBeforeDisappear);
            }
        }
    }

    // Método para desativar o objeto coletível
    void DeactivateCollectible()
    {
        gameObject.SetActive(false);
    }
}
