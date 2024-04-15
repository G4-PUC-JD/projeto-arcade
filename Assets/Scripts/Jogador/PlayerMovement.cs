using UnityEngine;

public class ControleBarco : MonoBehaviour
{
    public float velocidadeMaxima = 8f; // Velocidade máxima do barco
    public float aceleracao = 1f; // Taxa de aceleração do barco
    public float desaceleracao = 2f; // Taxa de desaceleração do barco
    public float velocidadeAtual = 0f; // Velocidade atual do barco
    public float speedBoostAmount = 2f; // Quantidade de aumento de velocidade com o speed boost
    public float speedBoostDuration = 20f; // Duração do speed boost em segundos

    private bool isSpeedBoosted = false; // Indica se o speed boost está ativo
    private float originalSpeed; // Velocidade original do barco sem o speed boost

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

    // Método para aplicar o aumento de velocidade (speed boost)
    public void ApplySpeedBoost()
    {
        // Verifica se o speed boost não está ativo
        if (!isSpeedBoosted)
        {
            // Ativa o speed boost
            isSpeedBoosted = true;
            originalSpeed = velocidadeMaxima;
            velocidadeMaxima *= speedBoostAmount; // Aumenta a velocidade máxima com base no speed boost amount
            desaceleracao = 10f;

            // Atualiza a velocidade atual para refletir a mudança na velocidade máxima
            velocidadeAtual *= speedBoostAmount;

            // Define a duração do speed boost
            Invoke("DisableSpeedBoost", speedBoostDuration);
        }
    }

    // Método para desativar o speed boost
    private void DisableSpeedBoost()
    {
        isSpeedBoosted = false;
        velocidadeMaxima = originalSpeed; // Retorna a velocidade máxima ao valor original
        velocidadeAtual /= speedBoostAmount; // Retorna a velocidade atual ao valor original
        desaceleracao = 2f;
    }
}
