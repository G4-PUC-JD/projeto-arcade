using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float attractionForce = 10f; // Força de atração do redemoinho

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calcula o vetor de direção para o centro do redemoinho
            Vector3 directionToCenter = transform.position - other.transform.position;

            // Aplica uma força de atração ao objeto na direção do centro do redemoinho
            rb.AddForce(directionToCenter.normalized * attractionForce, ForceMode.Force);
        }
    }
}