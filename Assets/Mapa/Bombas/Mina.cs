using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mine : MonoBehaviour
{
    public int damageAmount = 200; // Quantidade de dano que a mina causa
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
    // M�todo chamado quando um objeto entra na �rea de colis�o da mina
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barco"))
        {
          // Verifica se o objeto que entrou na �rea de colis�o tem o script PlayerHealth
          PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

          // Se o objeto tiver o script PlayerHealth
          if (playerHealth != null)
          {
            // Reduz a sa�de do jogador pelo valor de dano da mina
            playerHealth.TakeDamage(damageAmount);
            audioSource.Play();
            Invoke("DeactivateCollectible", delayBeforeDisappear);
          }
        }
        if (other.CompareTag("Bomba"))
        {
            audioSource.Play();
            Invoke("DeactivateCollectible", delayBeforeDisappear);
        }
    }
     void DeactivateCollectible()
    {
        Destroy(gameObject);
    }
}
