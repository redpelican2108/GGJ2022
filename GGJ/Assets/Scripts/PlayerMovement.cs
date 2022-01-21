using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private LayerMask platformMask;
    private Rigidbody2D rb;
    private BoxCollider2D _collider;
    private float gravity;
    private float jumpSpeed;
    private float xAxis;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();

        // Calculate gravity and jump speed
        gravity = -2 * jumpHeight / Mathf.Pow(jumpTime, 2);
        Physics2D.gravity = new Vector2(0, gravity);

        jumpSpeed =  -gravity * jumpTime;
    }

    private void Update()
    {
        GetMovementInputs();

        // Walking
        rb.velocity = new Vector2(xAxis * walkSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

    }

    private void GetMovementInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
    }

    private bool IsGrounded()
    {
        float delta = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, delta, platformMask);
        return raycastHit;
    }
}
