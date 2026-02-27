using UnityEngine;
using UnityEngine.UI;

public class WorldColorFilter : MonoBehaviour
{
    [SerializeField] private Image _filterImage;

    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _reverseColor;

    private void OnEnable()
    {
        SwitchGravitation.OnGravityChanged += ChangeColor;
    }

    private void OnDisable()
    {
        SwitchGravitation.OnGravityChanged -= ChangeColor;
    }

    private void ChangeColor(float direction)
    {
        if (direction == 1)
        {
            _filterImage.color = _normalColor;
        }
        else
        {
            _filterImage.color = _reverseColor;
        }
    }
}