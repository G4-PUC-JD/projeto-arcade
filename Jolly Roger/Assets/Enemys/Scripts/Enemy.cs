using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float shootChance = 0.5f; // Chance de falha ao atirar
    public float lateralOffset = 1f; // Offset lateral para o tiro

    public int currentHealth = 100;

    private void Update()
    {
        // Move para frente ou para trás
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotaciona para enfrentar o jogador
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0; // Ajusta para manter o inimigo nivelado
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Verifica se está na mira e atira
        if (IsAiming())
        {
            TryShoot();
        }
    }

    // Verifica se o jogador está na mira
    private bool IsAiming()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return Mathf.Abs(angle) < 45f; // Permite atirar se o jogador estiver dentro de um ângulo de 45 graus
    }

    // Tenta atirar
    private void TryShoot()
    {
        if (Random.value < shootChance)
        {
            Shoot();
        }
    }

    // Atira
    private void Shoot()
    {
        // Calcula o ponto ao lado do inimigo
        Vector3 shootPoint = transform.position + transform.right * lateralOffset;

        // Instancia a bala nesse ponto
        Instantiate(bulletPrefab, shootPoint, transform.rotation);
    }

        public void Die()
    {
        GameManager.enemyCount--;
        Destroy(gameObject);
    }

        public void TakeDamage(int damageAmount)
    {
        // Reduz os pontos de vida do jogador
        currentHealth -= damageAmount;

        // Verifica se os pontos de vida chegaram a zero ou menos
        if (currentHealth <= 0)
        {
            // Se sim, chama o m�todo para tratar a morte do jogador
            Die();
        }
    }
}
