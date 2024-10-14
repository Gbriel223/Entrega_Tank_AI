using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual como a vida m�xima
    }

    // Fun��o para reduzir a vida
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor do dano

        if (currentHealth <= 0f)
        {
            Die(); // Chama o m�todo de destrui��o do tanque
            Debug.Log("MORREU");
        }
    }

    // M�todo que destr�i o tanque
    void Die()
    {
       
        Destroy(gameObject); // Destr�i o objeto do tanque
    }
}