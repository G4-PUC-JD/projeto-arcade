using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundController : MonoBehaviour
{
    public AudioClip backgroundSound; // Áudio das ondas de fundo

    private AudioSource audioSource; // Componente AudioSource

    void Start()
    {
        // Adiciona e configura o componente AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundSound;
        audioSource.loop = true;

        // Inicia a reprodução do som de fundo
        audioSource.Play();
    }
}
