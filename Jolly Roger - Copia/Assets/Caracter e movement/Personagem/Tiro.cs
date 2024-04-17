using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public GameObject cannonballPrefab; // Prefab da bola de canh�o
    public Transform leftFirePoint; // Ponto de origem do tiro para o canh�o esquerdo
    public Transform rightFirePoint; // Ponto de origem do tiro para o canh�o direito
    public float fireRate = 0.5f; // Taxa de disparo (tiros por segundo)
    private float nextFireTime; // Tempo para o pr�ximo disparo

    // M�todo chamado uma vez no in�cio do jogo
    void Start()
    {
        // Inicializa o tempo para o pr�ximo disparo
        nextFireTime = 0f;
    }

    // M�todo chamado a cada frame
    void Update()
    {
        // Verifica se o jogador pressionou o bot�o de disparo e se j� passou o tempo para o pr�ximo disparo
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            // Define o tempo para o pr�ximo disparo com base na taxa de disparo
            nextFireTime = Time.time + 1f / fireRate;

            // Chama o m�todo para realizar o disparo no canh�o esquerdo
            Shoot(leftFirePoint);
        }
        else if (Input.GetButtonDown("Fire2") && Time.time >= nextFireTime)
        {
            // Define o tempo para o pr�ximo disparo com base na taxa de disparo
            nextFireTime = Time.time + 1f / fireRate;

            // Chama o m�todo para realizar o disparo no canh�o direito
            Shoot(rightFirePoint);
        }
    }

    // M�todo para realizar o disparo
    void Shoot(Transform firePoint)
    {
        // Instancia uma nova bola de canh�o no ponto de origem do tiro
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
    }
}
