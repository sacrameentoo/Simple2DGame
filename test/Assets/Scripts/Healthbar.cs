using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem target;
    [SerializeField] private Image fill;

    private void Update()
    {
        fill.fillAmount = target.GetPercent();
    }
}