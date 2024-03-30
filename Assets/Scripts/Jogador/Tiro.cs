using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab; // Prefab da bola de canhão
    public Transform leftFirePoint; // Ponto de origem do tiro para o canhão esquerdo
    public Transform rightFirePoint; // Ponto de origem do tiro para o canhão direito
    public float fireRate = 0.5f; // Taxa de disparo (tiros por segundo)
    private float nextFireTime; // Tempo para o próximo disparo

    // Método chamado uma vez no início do jogo
    void Start()
    {
        // Inicializa o tempo para o próximo disparo
        nextFireTime = 0f;
    }

    // Método chamado a cada frame
    void Update()
    {
        // Verifica se o jogador pressionou o botão de disparo e se já passou o tempo para o próximo disparo
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            // Define o tempo para o próximo disparo com base na taxa de disparo
            nextFireTime = Time.time + 1f / fireRate;

            // Chama o método para realizar o disparo no canhão esquerdo
            Shoot(leftFirePoint);
        }
        else if (Input.GetButtonDown("Fire2") && Time.time >= nextFireTime)
        {
            // Define o tempo para o próximo disparo com base na taxa de disparo
            nextFireTime = Time.time + 1f / fireRate;

            // Chama o método para realizar o disparo no canhão direito
            Shoot(rightFirePoint);
        }
    }

    // Método para realizar o disparo
    void Shoot(Transform firePoint)
    {
        // Instancia uma nova bola de canhão no ponto de origem do tiro
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
    }
}
