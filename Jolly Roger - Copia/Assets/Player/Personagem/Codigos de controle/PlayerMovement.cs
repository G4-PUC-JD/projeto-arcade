using UnityEngine;

public class ControleBarco : MonoBehaviour
{
    public float velocidadeMaxima = 8f; // Velocidade m�xima do barco
    public float aceleracao = 1f; // Taxa de acelera��o do barco
    public float desaceleracao = 2f; // Taxa de desacelera��o do barco
    public float velocidadeAtual = 0f; // Velocidade atual do barco
    public float speedBoostAmount = 2f; // Quantidade de aumento de velocidade com o speed boost
    public float speedBoostDuration = 20f; // Dura��o do speed boost em segundos

    private bool isSpeedBoosted = false; // Indica se o speed boost est� ativo
    private float originalSpeed; // Velocidade original do barco sem o speed boost

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
        if (entradaVertical <= 0)
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

    // M�todo para aplicar o aumento de velocidade (speed boost)
    public void ApplySpeedBoost()
    {
        // Verifica se o speed boost n�o est� ativo
        if (!isSpeedBoosted)
        {
            // Ativa o speed boost
            isSpeedBoosted = true;
            originalSpeed = velocidadeMaxima;
            velocidadeMaxima *= speedBoostAmount; // Aumenta a velocidade m�xima com base no speed boost amount
            desaceleracao = 1f;

            // Atualiza a velocidade atual para refletir a mudan�a na velocidade m�xima
            velocidadeAtual *= speedBoostAmount;

            // Define a dura��o do speed boost
            Invoke("DisableSpeedBoost", speedBoostDuration);
        }
    }

    // M�todo para desativar o speed boost
    private void DisableSpeedBoost()
    {
        isSpeedBoosted = false;
        velocidadeMaxima = originalSpeed; // Retorna a velocidade m�xima ao valor original
        velocidadeAtual /= speedBoostAmount; // Retorna a velocidade atual ao valor original
        desaceleracao = 2f;
    }
}
