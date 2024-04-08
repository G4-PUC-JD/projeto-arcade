using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawnbomba : MonoBehaviour
{
public GameObject objectToCreate;
public Vector3 minPosition;
public Vector3 maxPosition;
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
        Instantiate(objectToCreate, randomPosition, Quaternion.identity, transform);
        }
}
}
