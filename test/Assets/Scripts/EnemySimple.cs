using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    [SerializeField] private float attackCooldown = 1f;
    private Animator animator;
    private HealthSystem healthSystem;

    private float timer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && timer >= attackCooldown)
        {
            other.GetComponent<HealthSystem>()?.TakeDamage(damage);
            timer = 0;

            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    
    public void TakeDamage(int amount)
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
        
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(amount);
            if (healthSystem.GetPercent() <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
        
        Destroy(gameObject, 1f);
    }
}