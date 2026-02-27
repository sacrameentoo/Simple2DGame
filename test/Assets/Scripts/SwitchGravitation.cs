using UnityEngine;
using System;

public class SwitchGravitation : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public static event Action<float> OnGravityChanged;
    
    [SerializeField] private Player _player;

    private float gravityDirection = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _player.IsGrounded)
        {
            SwitchGravity();
        }
    }

    private void SwitchGravity()
    {
        gravityDirection *= -1;
        rb.gravityScale *= -1;

        OnGravityChanged?.Invoke(gravityDirection);
    }
}