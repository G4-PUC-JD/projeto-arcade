using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int damageAmount = 200; // Quantidade de dano que a mina causa
    public AudioClip explosionSound; // �udio de explos�o
    private AudioSource audioSource; // Componente de �udio da mina
    public float timeBeforeDeactivate = 1.5f; // Tempo antes de desativar a mina ap�s a explos�o

    void Start()
    {
        // Adiciona um componente de �udio � mina, se ainda n�o houver
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Define o �udio de explos�o para reprodu��o
        audioSource.clip = explosionSound;
    }

    // M�todo chamado quando um objeto entra na �rea de colis�o da mina
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea de colis�o tem o script PlayerHealth
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        // Se o objeto tiver o script PlayerHealth
        if (playerHealth != null)
        {
            // Reduz a sa�de do jogador pelo valor de dano da mina
            playerHealth.TakeDamage(damageAmount);
        }

        // Inicia a contagem regressiva para desativar a mina com o som de explos�o
        StartCoroutine(CountdownToDeactivate());
    }

    IEnumerator CountdownToDeactivate()
    {
        // Reproduz o som de explos�o 0.02 segundos antes de desativar a mina
        yield return new WaitForSeconds(0.02f);
        audioSource.Play();

        // Aguarda o tempo definido antes de desativar a mina
        yield return new WaitForSeconds(timeBeforeDeactivate - 0.5f); // Subtra�mos 0.02 segundos do tempo total para compensar a espera inicial de 0.2 segundos

        // Desativa a mina
        gameObject.SetActive(false);
    }
}
