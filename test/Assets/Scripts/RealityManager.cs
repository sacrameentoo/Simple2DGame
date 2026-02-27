using UnityEngine;

public class RealityManager : MonoBehaviour
{
    [SerializeField] private GameObject _normalWorld;
    [SerializeField] private GameObject _reverseWorld;

    private void OnEnable()
    {
        SwitchGravitation.OnGravityChanged += SwitchReality;
    }

    private void OnDisable()
    {
        SwitchGravitation.OnGravityChanged -= SwitchReality;
    }

    private void SwitchReality(float gravityDirection)
    {
        if (gravityDirection == 1)
        {
            _normalWorld.SetActive(true);
            _reverseWorld.SetActive(false);
        }
        else
        {
            _normalWorld.SetActive(false);
            _reverseWorld.SetActive(true);
        }
    }
}