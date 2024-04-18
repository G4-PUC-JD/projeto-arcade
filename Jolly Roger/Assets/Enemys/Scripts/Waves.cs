using UnityEngine;

public class Wave : MonoBehaviour
{
    public float waveForce = 100f; // Força da onda
    public float waveInterval = 5f; // Intervalo de tempo entre cada onda
    public float waveDuration = 1f; // Duração da onda
    private float timer = 0f; // Temporizador

    private void Update()
    {
        // Atualiza o temporizador
        timer += Time.deltaTime;

        // Se o temporizador atingir o intervalo desejado
        if (timer >= waveInterval)
        {
            // Reinicia o temporizador
            timer = 0f;

            // Gera uma direção aleatória para a onda
            Vector3 waveDirection = Random.insideUnitSphere;
            waveDirection.y = 0f; // Mantém a onda no plano XY

            // Aplica a força da onda na direção aleatória
            GetComponent<Rigidbody>().AddForce(waveDirection.normalized * waveForce, ForceMode.Impulse);

            // Desativa o campo de força após a duração da onda
            Invoke("DisableWave", waveDuration);
        }
    }

    private void DisableWave()
    {
        // Remove a força da onda
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}