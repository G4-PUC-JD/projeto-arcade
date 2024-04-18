using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo a ser spawnado
    public int numberOfEnemies = 10; // Número total de inimigos a serem spawnados
    public float radius = 5f; // Raio do anel
    public float yOffset = 0.5f; // Altura em relação ao jogador
    public float spawnInterval = 5f; // Intervalo de tempo entre cada spawn
    private float timer = 0f; // Temporizador

    void Start()
    {
        // Inicia o temporizador
        timer = spawnInterval;
    }

    void Update()
    {
        // Atualiza o temporizador
        timer -= Time.deltaTime;

        // Se o temporizador atingir zero ou menos
        if (timer <= 0f)
        {
          // Se iniciar a luta contra o boss, não spawna mais inimigos
            if(!GameManager.bossFight) return;
            // Se não houver inimigos, gera um miniboss
            if (GameManager.enemyCount == 0)
            {
                SpawnMiniboss();
            }
            else
            {
                // Spawn do inimigo
                SpawnEnemy();
            }

            // Reinicia o temporizador
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Calcula uma posição aleatória ao redor do jogador
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPosition = transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * radius;
        spawnPosition.y = yOffset; // Ajusta a altura

        // Instancia o inimigo nessa posição
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        GameManager.enemyCount++;
    }

        void SpawnMiniboss()
    {
        // Instancia o miniboss nessa posição
        GameManager.bossFight = true;
        Instantiate(minibossPrefab, spawnPosition, Quaternion.identity, transform);
    }
}