using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBarco : MonoBehaviour
{
    float velocidadeMaxima = 8f; // Velocidade máxima do barco
    float aceleracao = 1f; // Taxa de aceleração do barco
    float desaceleracao = 2f; // Taxa de desaceleração do barco

    float velocidadeAtual = 0f; // Velocidade atual do barco

    // Update é chamado uma vez por quadro
    void Update()
    {
        // Obtenha a entrada horizontal para virar
        float entradaHorizontal = Input.GetAxis("Horizontal");

        // Rotacionar o barco para a esquerda ou direita com base na entrada
        transform.Rotate(Vector3.up, entradaHorizontal * Time.deltaTime * 100f);

        // Obtenha a entrada vertical para movimento para frente/para trás
        float entradaVertical = Input.GetAxis("Vertical");

        // Se a entrada vertical for negativa (seta para baixo), aplicar desaceleração
        if (entradaVertical < 0)
        {
            velocidadeAtual -= desaceleracao * Time.deltaTime;
        }
        else
        {
            // Caso contrário, aumente a velocidade atual com base na aceleração
            velocidadeAtual += entradaVertical * aceleracao * Time.deltaTime;
        }

        // Limita a velocidade atual à velocidade máxima
        velocidadeAtual = Mathf.Clamp(velocidadeAtual, 0f, velocidadeMaxima);

        // Move o barco para frente
        transform.Translate(Vector3.forward * velocidadeAtual * Time.deltaTime);
    }
}
