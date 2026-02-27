using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator animator;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("IsTriggered");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("IsTriggered");
        }
    }
}
