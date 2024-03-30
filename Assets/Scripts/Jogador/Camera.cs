using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Refer�ncia ao objeto que a c�mera vai seguir

    // Offset da c�mera em rela��o ao jogador
    public float cameraHeight = 10f;
    public float cameraDistance = 5f;

    // Velocidade de suaviza��o do movimento da c�mera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Calcula a posi��o desejada da c�mera
        Vector3 desiredPosition = target.position - target.forward * cameraDistance + Vector3.up * cameraHeight;
        // Interpola suavemente entre a posi��o atual e a posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Define a nova posi��o da c�mera
        transform.position = smoothedPosition;

        // A c�mera sempre olha para o jogador
        transform.LookAt(target);
    }
}

