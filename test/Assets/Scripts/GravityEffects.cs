using UnityEngine;

public class GravityEffects : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private Vector3 startPos;
    private float shakeTime;
    private bool isShaking;

    private void OnEnable()
    {
        SwitchGravitation.OnGravityChanged += StartShake;
    }

    private void OnDisable()
    {
        SwitchGravitation.OnGravityChanged -= StartShake;
    }

    private void StartShake(float direction)
    {
        isShaking = true;
        shakeTime = 0;
        startPos = _cameraTransform.localPosition;
    }

    private void Update()
    {
        if (!isShaking)
        { 
            return;
        }

        shakeTime += Time.deltaTime;

        if (shakeTime < 0.2f)
        {
            float moveByXRange = Random.Range(-0.2f, 0.2f);
            float moveByYRange = Random.Range(-0.2f, 0.2f);

            _cameraTransform.localPosition = startPos + new Vector3(moveByXRange, moveByYRange, 0);
        }
        else
        {
            isShaking = false;
            _cameraTransform.localPosition = startPos;
        }
    }
}