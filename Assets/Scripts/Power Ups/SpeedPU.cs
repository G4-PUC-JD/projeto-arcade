using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPU : MonoBehaviour
{

    // Método chamado quando um objeto entra na área de colisão do impulso de velocidade
    // Método chamado quando um objeto entra na área de colisão do impulso de velocidade
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na área de colisão é o jogador
        if (other.CompareTag("Barco"))
        {
            // Obtém o componente ControleBarco do jogador
            ControleBarco playerController = other.GetComponent<ControleBarco>();

            // Se o componente ControleBarco existir no jogador
            if (playerController != null)
            {
                // Ativa o aumento de velocidade no jogador
                playerController.ApplySpeedBoost();

                // Desativa o objeto que concedeu o impulso de velocidade
                gameObject.SetActive(false);
            }
        }
    }
}
