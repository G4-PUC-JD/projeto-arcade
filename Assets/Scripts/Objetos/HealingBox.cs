using UnityEngine;

public class HealingBox : MonoBehaviour
{
    public int healingAmount = 100; // Quantidade de vida que a caixa de cura fornece
    public AudioClip pickupSound; // Som a ser reproduzido ao coletar a caixa de cura
    public float delayBeforeDisappear = 0.5f; // Tempo de espera antes da caixa de cura desaparecer

    private AudioSource audioSource; // Componente de áudio para reproduzir o som

    void Start()
    {
        // Adiciona um componente de áudio ao objeto da caixa de cura
        audioSource = gameObject.AddComponent<AudioSource>();
        // Atribui o som ao componente de áudio
        audioSource.clip = pickupSound;
    }

    // Método chamado quando um objeto entra na área de colisão da caixa de cura
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou na área de colisão é o jogador
        if (other.CompareTag("Barco"))
        {
            // Obtém o script PlayerHealth do jogador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Se o script PlayerHealth existir no jogador
            if (playerHealth != null)
            {
                // Reproduz o som de coleta
                audioSource.Play();

                // Aumenta a saúde do jogador pelo valor de cura da caixa de cura após um pequeno atraso
                Invoke("HealPlayer", delayBeforeDisappear);
            }
        }
    }

    // Método para aumentar a saúde do jogador
    void HealPlayer()
    {
        // Obtém o script PlayerHealth do jogador
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Barco").GetComponent<PlayerHealth>();

        // Se o script PlayerHealth existir no jogador
        if (playerHealth != null)
        {
            // Aumenta a saúde do jogador pelo valor de cura da caixa de cura
            playerHealth.Heal(healingAmount);

            // Desativa a caixa de cura após um pequeno atraso
            Invoke("DeactivateHealingBox", delayBeforeDisappear);
        }
    }

    // Método para desativar a caixa de cura
    void DeactivateHealingBox()
    {
        Destroy(gameObject);
    }
}
