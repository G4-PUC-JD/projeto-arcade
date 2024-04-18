using UnityEngine;

public class CannonBall : MonoBehaviour
{
  public float speed = 10f;
  public float lifetime = 3f;
  public GameObject target;

  public int damageAmount = 10;

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

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject == target)
    {
      Target targetScript = target.GetComponent<Target>();
      if (targetScript != null)
      {
        targetScript.TakeDamage(damageAmount);
      }

      Destroy(gameObject);
    }
  }
}