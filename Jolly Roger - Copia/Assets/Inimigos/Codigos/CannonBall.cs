using UnityEngine;

public class CannonBall : MonoBehaviour
{
  public float speed = 10f;
  public float lifetime = 3f;
  public int damageAmount = 10;
  public GameObject target;

    private void Start()
  {
    Destroy(gameObject, lifetime);
  }

  private void Update()
  {
    if (target != null)
    {
      Vector3 direction = (target.transform.position - transform.position).normalized;
      transform.Translate(direction * speed * Time.deltaTime);
    }
  }
  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barco"))
        {
          // Verifica se o objeto que entrou na �rea de colis�o tem o script PlayerHealth
          PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

          // Se o objeto tiver o script PlayerHealth
          if (playerHealth != null)
          {
            // Reduz a sa�de do jogador pelo valor de dano da mina
            playerHealth.TakeDamage(damageAmount);
            Destroy(gameObject);
          }
      }
    }
}