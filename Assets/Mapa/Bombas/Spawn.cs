using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawnbomba : MonoBehaviour
{
public GameObject objectToCreate;
public Vector3 minPosition;
public Vector3 maxPosition;
public Vector3 minRotation;
public Vector3 maxRotation;
public int quantidade;
void Start()
{
        for (int spawn = 0; spawn < quantidade; spawn++)
        {
        Vector3 randomPosition = new Vector3(
        Random.Range(minPosition.x, maxPosition.x),
        Random.Range(minPosition.y, maxPosition.y),
        Random.Range(minPosition.z, maxPosition.z)
        );
        Vector3 randomRotation = new Vector3(
        Random.Range(minRotation.x, maxRotation.x),
        Random.Range(minRotation.y, maxRotation.y),
        Random.Range(minRotation.z, maxRotation.z)
        );
        Instantiate(objectToCreate, randomPosition, Quaternion.Euler(randomRotation), transform);
        }
}
}
