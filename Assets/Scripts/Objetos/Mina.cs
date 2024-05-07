using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int damageAmount = 200; // Quantidade de dano que a mina causa
    public AudioClip explosionSound; // Áudio de explosão
    private AudioSource audioSource; // Componente de áudio da mina
    public float timeBeforeDeactivate = 1.5f; // Tempo antes de desativar a mina após a explosão

    void Start()
    {
        // Adiciona um componente de áudio à mina, se ainda não houver
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Define o áudio de explosão para reprodução
        audioSource.clip = explosionSound;
    }

    // Método chamado quando um objeto entra na área de colisão da mina
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na área de colisão tem o script PlayerHealth
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        // Se o objeto tiver o script PlayerHealth
        if (playerHealth != null)
        {
            // Reduz a saúde do jogador pelo valor de dano da mina
            playerHealth.TakeDamage(damageAmount);
        }

        // Inicia a contagem regressiva para desativar a mina com o som de explosão
        StartCoroutine(CountdownToDeactivate());
    }

    IEnumerator CountdownToDeactivate()
    {
        // Reproduz o som de explosão 0.02 segundos antes de desativar a mina
        yield return new WaitForSeconds(0.02f);
        audioSource.Play();

        // Aguarda o tempo definido antes de desativar a mina
        yield return new WaitForSeconds(timeBeforeDeactivate - 0.5f); // Subtraímos 0.02 segundos do tempo total para compensar a espera inicial de 0.2 segundos

        // Desativa a mina
        gameObject.SetActive(false);
    }
}
