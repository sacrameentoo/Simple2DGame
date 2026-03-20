using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public GameObject hitEffect;
    public GameObject deathEffect;

    public bool isPlayer = false;
    public Transform respawnPoint;

    private void Start()
    {
        currentHealth = maxHealth;
        
        if (isPlayer && respawnPoint == null)
        {
            respawnPoint = new GameObject("RespawnPoint").transform;
            respawnPoint.position = transform.position;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead || damage <= 0)
        {
            return;
        }

        currentHealth -= damage;

        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int value)
    {
        if (isDead || value <= 0)
        {
            return;
        }

        currentHealth = Mathf.Min(currentHealth + value, maxHealth);
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;

        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        
        foreach (var comp in GetComponents<MonoBehaviour>())
        {
            if (comp != this)
                comp.enabled = false;
        }
        
        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null) rend.enabled = false;

        if (isPlayer)
        {
            Invoke(nameof(Respawn), 2f);
        }
        else
        {
            Destroy(gameObject, 0.01f);
        }
    }

    private void Respawn()
    {
        currentHealth = maxHealth;
        isDead = false;
        
        foreach (var comp in GetComponents<MonoBehaviour>())
        {
            if (comp != this)
            {
                comp.enabled = true;
            }
        }
        
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }

        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.enabled = true;
        }
        
        transform.position = respawnPoint.position;
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public float GetPercent()
    {
        return (float)currentHealth / maxHealth;
    }
}