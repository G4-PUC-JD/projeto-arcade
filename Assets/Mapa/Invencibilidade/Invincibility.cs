using UnityEngine;
using UnityEngine.Audio;

public class InvincibilityCollectible : MonoBehaviour
{
    public AudioClip collectSound; // Som a ser reproduzido ao coletar o colet�vel de invencibilidade
    public float delayBeforeDisappear = 0.5f; // Tempo de espera antes do objeto desaparecer
    public AudioMixerGroup audioMixer;

    private AudioSource audioSource; // Componente de �udio para reproduzir o som

    void Start()
    {
        // Adiciona um componente de �udio ao objeto colet�vel
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de �udio
        audioSource.clip = collectSound;
        audioSource.outputAudioMixerGroup = audioMixer;
    }

    // M�todo chamado quando um objeto entra na �rea de colis�o do colet�vel de invencibilidade
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea de colis�o � o jogador
        if (other.CompareTag("Barco"))
        {
            // Obt�m o componente InvincibilityController do jogador
            InvincibilityController invincibilityController = other.GetComponent<InvincibilityController>();

            // Se o componente InvincibilityController existir no jogador
            if (invincibilityController != null)
            {
                // Coleta o ponto de invencibilidade
                invincibilityController.CollectInvincibilityPoint();

                // Reproduz o som de coleta
                audioSource.Play();

                // Desativa o objeto que concedeu o ponto de invencibilidade ap�s um pequeno atraso
                // Para garantir que o som seja reproduzido antes que o objeto seja desativado
                Invoke("DeactivateCollectible", delayBeforeDisappear);
            }
        }
    }

    // M�todo para desativar o objeto colet�vel
    void DeactivateCollectible()
    {
        Destroy(gameObject);
    }
}