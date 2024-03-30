using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBarco : MonoBehaviour
{
    float velocidadeMaxima = 8f; // Velocidade m�xima do barco
    float aceleracao = 1f; // Taxa de acelera��o do barco
    float desaceleracao = 2f; // Taxa de desacelera��o do barco

    float velocidadeAtual = 0f; // Velocidade atual do barco

    // Update � chamado uma vez por quadro
    void Update()
    {
        // Obtenha a entrada horizontal para virar
        float entradaHorizontal = Input.GetAxis("Horizontal");

        // Rotacionar o barco para a esquerda ou direita com base na entrada
        transform.Rotate(Vector3.up, entradaHorizontal * Time.deltaTime * 100f);

        // Obtenha a entrada vertical para movimento para frente/para tr�s
        float entradaVertical = Input.GetAxis("Vertical");

        // Se a entrada vertical for negativa (seta para baixo), aplicar desacelera��o
        if (entradaVertical < 0)
        {
            velocidadeAtual -= desaceleracao * Time.deltaTime;
        }
        else
        {
            // Caso contr�rio, aumente a velocidade atual com base na acelera��o
            velocidadeAtual += entradaVertical * aceleracao * Time.deltaTime;
        }

        // Limita a velocidade atual � velocidade m�xima
        velocidadeAtual = Mathf.Clamp(velocidadeAtual, 0f, velocidadeMaxima);

        // Move o barco para frente
        transform.Translate(Vector3.forward * velocidadeAtual * Time.deltaTime);
    }
}
