using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private LayerMask platformMask;
    private Rigidbody2D rb;
    private BoxCollider2D _collider;
    private Animator animator;
    private float gravity;
    private float jumpSpeed;
    private float xAxis;
    private bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        // Calculate gravity and jump speed
        gravity = -2 * jumpHeight / Mathf.Pow(jumpTime, 2);
        Physics2D.gravity = new Vector2(0, gravity);

        jumpSpeed =  -gravity * jumpTime;
    }

    private void Update()
    {
        GetMovementInputs();

        // Walking
        Move();

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        // Animation
        animator.SetFloat("walkSpeed", Mathf.Abs(xAxis));

        if (IsGrounded())
        {
            animator.SetBool("jump", false);
        }
        else 
        {
            animator.SetBool("jump", true);
        }
    }

    private void GetMovementInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        if (xAxis > 0 && facingRight)
        {
            Flip();
        }
        else if (xAxis < 0 && !facingRight)
        {
            Flip();
        }

        rb.velocity = new Vector2(xAxis * walkSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private bool IsGrounded()
    {
        float delta = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, delta, platformMask);
        return raycastHit;
    }
}
