using UnityEngine;

public class SlowArea : MonoBehaviour
{
    public float slowFactor = 0.5f; // Fator de redução da velocidade

    private void OnTriggerStay(Collider other)
    {
        // Verifica se o objeto que está dentro da área possui um componente Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Reduz a velocidade do objeto
            rb.velocity *= slowFactor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu da área possui um componente Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Restaura a velocidade original do objeto
            rb.velocity /= slowFactor;
        }
    }
}