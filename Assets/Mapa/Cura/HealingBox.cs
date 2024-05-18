using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealingBox : MonoBehaviour
{
    public int healingAmount = 100; // Quantidade de vida que a caixa de cura fornece
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

    // M�todo chamado quando um objeto entra na �rea de colis�o da caixa de cura
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea de colis�o � o jogador
        if (other.CompareTag("Barco"))
        {
            // Obt�m o script PlayerHealth do jogador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Se o script PlayerHealth existir no jogador
            if (playerHealth != null)
            {
                // Aumenta a sa�de do jogador pelo valor de cura da caixa de cura
                playerHealth.Heal(healingAmount);
                audioSource.Play();

                // Desativa a caixa de cura ap�s ser tocada pelo jogador
                Invoke("DeactivateCollectible", delayBeforeDisappear);
            }
        }
    }
     void DeactivateCollectible()
    {
        Destroy(gameObject);
    }
}