using UnityEngine;

public class MiniBoss : MonoBehaviour
{
  public BossCannon bossCannonPrefab;
  public Transform leftSpawnPoint;
  public Transform rightSpawnPoint;

  private BossCannon[] bossCannons;
  public int currentHealth = 1000;

  private void Start()
  {
    bossCannons = new BossCannon[8];

    // Spawn BossCannons à esquerda
    for (int i = 0; i < 4; i++)
    {
      Vector3 spawnPosition = leftSpawnPoint.position + new Vector3(0f, i * 2f, 0f);
      bossCannons[i] = Instantiate(bossCannonPrefab, spawnPosition, Quaternion.identity);
    }

    // Spawn BossCannons à direita
    for (int i = 0; i < 4; i++)
    {
      Vector3 spawnPosition = rightSpawnPoint.position + new Vector3(0f, i * 2f, 0f);
      bossCannons[i + 4] = Instantiate(bossCannonPrefab, spawnPosition, Quaternion.identity);
    }
  }

    public void Die()
    {
        GameManager.victory = true;
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