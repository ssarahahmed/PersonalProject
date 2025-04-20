using UnityEngine;
using UnityEngine.UI;

public class HealthTimer : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    public float drainRate = 0.2f; 
    private float currentHealth;
    private float timer;

    void Start()
    {
        currentHealth = maxHealth;
        timer = 0f;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        timer += Time.deltaTime;
        currentHealth -= drainRate * Time.deltaTime;

        
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar.value = currentHealth;

        if (currentHealth <= 0f)
        {
            Debug.Log("Game Over! 🧀");
            
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar.value = currentHealth;
    }
}
