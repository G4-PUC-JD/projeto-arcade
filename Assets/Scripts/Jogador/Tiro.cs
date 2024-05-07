using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab; // Prefab da bola de canhão
    public Transform[] leftFirePoints; // Pontos de origem do tiro para os canhões esquerdos
    public Transform[] rightFirePoints; // Pontos de origem do tiro para os canhões direitos
    public float fireRate = 0.5f; // Taxa de disparo (tiros por segundo)
    private AudioSource audioSource; // Componente de áudio do barco
    private float nextFireTime; // Tempo para o próximo disparo

    // Método chamado uma vez no início do jogo
    void Start()
    {
        // Inicializa o tempo para o próximo disparo
        nextFireTime = 0f;

        // Obtém o componente de áudio do barco
        audioSource = GetComponent<AudioSource>();
    }

    // Método chamado a cada frame
    void Update()
    {
        // Verifica se o jogador pressionou o botão de disparo e se já passou o tempo para o próximo disparo
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Time.time >= nextFireTime)
        {
            // Define o tempo para o próximo disparo com base na taxa de disparo
            nextFireTime = Time.time + 1f / fireRate;

            // Reproduz o som de tiro
            audioSource.Play();

            // Chama o método para realizar o disparo em todos os canhões do lado esquerdo
            if (Input.GetButtonDown("Fire1"))
            {
                foreach (Transform firePoint in leftFirePoints)
                {
                    Shoot(firePoint);
                }
            }
            // Chama o método para realizar o disparo em todos os canhões do lado direito
            else if (Input.GetButtonDown("Fire2"))
            {
                foreach (Transform firePoint in rightFirePoints)
                {
                    Shoot(firePoint);
                }
            }
        }
    }

    // Método para realizar o disparo
    void Shoot(Transform firePoint)
    {
        // Instancia uma nova bola de canhão no ponto de origem do tiro
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
    }
}
