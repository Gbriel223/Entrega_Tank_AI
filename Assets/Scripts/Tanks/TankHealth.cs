using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual como a vida máxima
    }

    // Função para reduzir a vida
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor do dano

        if (currentHealth <= 0f)
        {
            Die(); // Chama o método de destruição do tanque
            Debug.Log("MORREU");
        }
    }

    // Método que destrói o tanque
    void Die()
    {
       
        Destroy(gameObject); // Destrói o objeto do tanque
    }
}