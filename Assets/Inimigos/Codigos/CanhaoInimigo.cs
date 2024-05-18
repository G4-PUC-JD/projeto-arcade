using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CanhaoInimigo : MonoBehaviour
{
    public int damageAmount = 20;
    public float speed = 30f;
    public AudioClip collectSound; // Som a ser reproduzido ao coletar o colet�vel de invencibilidade
    public AudioMixerGroup audioMixer;
    private AudioSource audioSource;
    public float delayBeforeDisappear = 0.5f;
    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de �udio
        audioSource.clip = collectSound;
        audioSource.outputAudioMixerGroup = audioMixer;
    }
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
      
    }
    void DeactivateCollectible()
    {
        Destroy(gameObject);
    }
}
