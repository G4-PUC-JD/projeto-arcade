using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab; // Prefab da bola de canh�o
    public Transform[] leftFirePoints; // Pontos de origem do tiro para os canh�es esquerdos
    public Transform[] rightFirePoints; // Pontos de origem do tiro para os canh�es direitos
    public float fireRate = 0.5f; // Taxa de disparo (tiros por segundo)
    private float nextFireTime; // Tempo para o pr�ximo disparo
    public AudioClip collectSound; // Som a ser reproduzido ao coletar o colet�vel de invencibilidade
    public AudioMixerGroup audioMixer;
    private AudioSource audioSource;

    // M�todo chamado uma vez no in�cio do jogo
    void Start()
    {
        // Inicializa o tempo para o pr�ximo disparo
        nextFireTime = 0f;
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de �udio
        audioSource.clip = collectSound;
        audioSource.outputAudioMixerGroup = audioMixer;
    }

    // M�todo chamado a cada frame
    void Update()
    {
        // Verifica se o jogador pressionou o bot�o de disparo e se j� passou o tempo para o pr�ximo disparo
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Time.time >= nextFireTime)
        {
            // Define o tempo para o pr�ximo disparo com base na taxa de disparo
            nextFireTime = Time.time + 1f / fireRate;
            audioSource.Play();

            // Chama o m�todo para realizar o disparo em todos os canh�es do lado esquerdo
            if (Input.GetButtonDown("Fire1"))
            {
                foreach (Transform firePoint in leftFirePoints)
                {
                    Shoot(firePoint);
                }
            }
            // Chama o m�todo para realizar o disparo em todos os canh�es do lado direito
            else if (Input.GetButtonDown("Fire2"))
            {
                foreach (Transform firePoint in rightFirePoints)
                {
                    Shoot(firePoint);
                }
            }
        }
    }

    // M�todo para realizar o disparo
    void Shoot(Transform firePoint)
    {
        // Instancia uma nova bola de canh�o no ponto de origem do tiro
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
    }
}
