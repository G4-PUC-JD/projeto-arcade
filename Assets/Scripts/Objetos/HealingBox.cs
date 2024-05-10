using UnityEngine;

public class HealingBox : MonoBehaviour
{
    public int healingAmount = 100; // Quantidade de vida que a caixa de cura fornece
    public AudioClip pickupSound; // Som a ser reproduzido ao coletar a caixa de cura
    public float delayBeforeDisappear = 0.5f; // Tempo de espera antes da caixa de cura desaparecer

    private AudioSource audioSource; // Componente de �udio para reproduzir o som

    void Start()
    {
        // Adiciona um componente de �udio ao objeto da caixa de cura
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de �udio
        audioSource.clip = pickupSound;
    }

    // M�todo chamado quando um objeto entra na �rea de colis�o da caixa de cura
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na �rea de colis�o � o jogador
        if (other.CompareTag("Barco"))
        {
            // Obt�m o script PlayerHealth do jogador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Se o script PlayerHealth existir no jogador
            if (playerHealth != null)
            {
                // Reproduz o som de coleta
                audioSource.Play();

                // Aumenta a sa�de do jogador pelo valor de cura da caixa de cura ap�s um pequeno atraso
                Invoke("HealPlayer", delayBeforeDisappear);
            }
        }
    }

    // M�todo para aumentar a sa�de do jogador
    void HealPlayer()
    {
        // Obt�m o script PlayerHealth do jogador
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Barco").GetComponent<PlayerHealth>();

        // Se o script PlayerHealth existir no jogador
        if (playerHealth != null)
        {
            // Aumenta a sa�de do jogador pelo valor de cura da caixa de cura
            playerHealth.Heal(healingAmount);

            // Desativa a caixa de cura ap�s um pequeno atraso
            Invoke("DeactivateHealingBox", delayBeforeDisappear);
        }
    }

    // M�todo para desativar a caixa de cura
    void DeactivateHealingBox()
    {
        Destroy(gameObject);
    }
}
