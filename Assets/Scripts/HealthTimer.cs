using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthTimer : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    public float drainRate = 0.2f; 
    private float currentHealth;
    private float timer;
    private bool gamestart = false;

    void Start()
    {
        currentHealth = maxHealth;
        timer = 0f;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        if (!gamestart) return;

        timer += Time.deltaTime;
        currentHealth -= drainRate * Time.deltaTime;

        
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar.value = currentHealth;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f; 
            FindObjectOfType<PlayerController>().CheckHealth(currentHealth);
        }

    }

    public void StartTimer()
    {
        gamestart = true;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar.value = currentHealth;
    }

    public void ReduceHealth()
    {
        currentHealth -= 10f;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            FindObjectOfType<PlayerController>().CheckHealth(currentHealth);
        }
    }
}
