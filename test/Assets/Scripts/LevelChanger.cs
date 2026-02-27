using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private string sceneName;

    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            fadeAnimator.SetTrigger("Fade");
        }
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}