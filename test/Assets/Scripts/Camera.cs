using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float CameraSpeed;

    [SerializeField] private Vector2 _minBounds;
    [SerializeField] private Vector2 _maxBounds;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset,CameraSpeed * Time.fixedDeltaTime);

        nextPosition.x = Mathf.Clamp(nextPosition.x, _minBounds.x, _maxBounds.x);
        nextPosition.y = Mathf.Clamp(nextPosition.y, _minBounds.y, _maxBounds.y);

        transform.position = nextPosition;
    }
}
