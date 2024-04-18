using UnityEngine;

public class BossCannon : MonoBehaviour
{
    public Transform player; // Transform do jogador
    public float rotationSpeed = 5f; // Velocidade de rotação do canhão

    void Update()
    {
        // Calcula a direção para o jogador
        Vector3 directionToPlayer = player.position - transform.position;

        // Calcula a rotação para enfrentar o jogador
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Rotaciona gradualmente o canhão para enfrentar o jogador
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}