using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referência ao objeto que a câmera vai seguir

    // Offset da câmera em relação ao jogador
    public float cameraHeight = 10f;
    public float cameraDistance = 5f;

    // Velocidade de suavização do movimento da câmera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 desiredPosition = target.position - target.forward * cameraDistance + Vector3.up * cameraHeight;
        // Interpola suavemente entre a posição atual e a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Define a nova posição da câmera
        transform.position = smoothedPosition;

        // A câmera sempre olha para o jogador
        transform.LookAt(target);
    }
}
//So testando novamente