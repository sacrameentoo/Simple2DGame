using UnityEngine;

public class EnemyPoison : MonoBehaviour
{
    [SerializeField] private int poisonDamage = 5;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerBuffSystem>()?.ApplyPoison(poisonDamage);
            
            animator.SetTrigger("Attack");
        }
    }
    
    public void TakeDamage(int amount)
    {
        animator.SetTrigger("Hurt");
        
        HealthSystem health = GetComponent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(amount);
            if (health.GetPercent() <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
        
        Destroy(gameObject, 1f);
    }
}