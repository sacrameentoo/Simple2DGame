using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private float _checkRadius;
    
    private float moveInput;
    private bool facingRight = true;
    private float gravityDirection = 1f;
    private float imageScaleY = 4f;
    
    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    
    
    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SwitchGravitation.OnGravityChanged += GravityDirection;
    }

    private void OnDisable()
    {
        SwitchGravitation.OnGravityChanged -= GravityDirection;
    }

    private void GravityDirection(float direction)
    {
        gravityDirection = direction;

        Vector3 scale = transform.localScale;
        scale.y = direction * imageScaleY;
        transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * _moveSpeed, rb.velocity.y);

        if (moveInput != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius, _groundLayer);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * gravityDirection * _jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("TakeOf");
        }

        if (isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
    }
    

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
