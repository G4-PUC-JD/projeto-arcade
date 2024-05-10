using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPU : MonoBehaviour
{
    public AudioClip pickupSound; // Som a ser reproduzido ao coletar o impulso de velocidade
    public float delayBeforeDisappear = 0.5f; // Tempo de espera antes do objeto desaparecer

    private AudioSource audioSource; // Componente de �udio para reproduzir o som

    void Start()
    {
        // Adiciona um componente de �udio ao objeto do impulso de velocidade
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de �udio
        audioSource.clip = pickupSound;
    }

    // M�todo chamado quando um objeto entra na �rea de colis�o do impulso de velocidade
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea de colis�o � o jogador
        if (other.CompareTag("Barco"))
        {
            // Obt�m o componente ControleBarco do jogador
            ControleBarco playerController = other.GetComponent<ControleBarco>();

            // Se o componente ControleBarco existir no jogador
            if (playerController != null)
            {
                // Reproduz o som de coleta
                audioSource.Play();

                // Ativa o aumento de velocidade no jogador ap�s um pequeno atraso
                Invoke("ApplySpeedBoost", delayBeforeDisappear);
            }
        }
    }

    // M�todo para ativar o aumento de velocidade no jogador
    void ApplySpeedBoost()
    {
        // Obt�m o componente ControleBarco do jogador
        ControleBarco playerController = GameObject.FindGameObjectWithTag("Barco").GetComponent<ControleBarco>();

        // Se o componente ControleBarco existir no jogador
        if (playerController != null)
        {
            // Ativa o aumento de velocidade no jogador
            playerController.ApplySpeedBoost();

            // Desativa o objeto do impulso de velocidade ap�s um pequeno atraso
            Invoke("DeactivateSpeedPU", delayBeforeDisappear);
        }
    }

    // M�todo para desativar o objeto do impulso de velocidade
    void DeactivateSpeedPU()
    {
        gameObject.SetActive(false);
    }
}
