using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private LayerMask platformMask;
    public bool stageComplete;
    public bool gamePaused;
    public bool isUpsideDown;
    private Rigidbody2D rb;
    private BoxCollider2D _collider;
    private Animator animator;
    private float gravity;
    private float jumpSpeed;
    private float xAxis;
    private bool facingRight;
    private Portal exit = null;
    private ScreenWipe screenWipe;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        // Calculate gravity and jump speed
        gravity = -2 * jumpHeight / Mathf.Pow(jumpTime, 2);
        Physics2D.gravity = new Vector2(0, gravity);

        jumpSpeed =  -gravity * jumpTime;

        stageComplete = false;
        gamePaused = false;
        isUpsideDown = false;

        screenWipe = GameObject.FindGameObjectWithTag("ScreenWipe").GetComponent<ScreenWipe>();
    }

    private void Update()
    {
        if (!stageComplete && !gamePaused)
        {
            GetMovementInputs();
        }

        // Walking
        Move();

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            if (!isUpsideDown)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            } else
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpSpeed);
            }
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

        if (stageComplete)
        {
            xAxis = 0;
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
        float delta = 0.5f;
        RaycastHit2D raycastHit;
        if (!isUpsideDown)
        {
            raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, delta, platformMask);
        } 
        else
        {
            raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.up, delta, platformMask);
        }
        return raycastHit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spikes")
        {
            StartCoroutine(RestartLevel());
        }

        if (collision.tag == "Portal" && exit == null)
        {
            exit = collision.GetComponent<Portal>().other;
            transform.position = exit.transform.position;
            if (exit.oneTime)
            {
                Destroy(collision.gameObject);
                Destroy(exit.gameObject);
                exit = null;
            }
        }

        if (collision.tag == "Button")
        {
            collision.GetComponent<GameButton>().Press(true);
        }

        if (collision.tag == "MovingPlatform")
        {
            transform.SetParent(collision.transform);
        }

        if (collision.tag == "DartTrap")
        {
            collision.GetComponent<DartTrap>().Target(transform);
        }

        if (collision.tag == "Dart")
        {
            Destroy(collision.gameObject);

            // Restart the level
            StartCoroutine(RestartLevel());
        }

        if (collision.tag == "Gravity")
        {
            Destroy(collision.gameObject);
            isUpsideDown = !isUpsideDown;
            TurnUpsideDown();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Portal" && exit == collision.GetComponent<Portal>())
        {
            exit = null;
        }

        if (collision.tag == "Button")
        {
            collision.GetComponent<GameButton>().Press(false);
        }

        if (collision.tag == "MovingPlatform")
        {
            transform.SetParent(null);
        }

        if (collision.tag == "DartTrap")
        {
            collision.GetComponent<DartTrap>().Stop();
        }
    }

    public void TurnUpsideDown()
    {
        rb.gravityScale = -rb.gravityScale;
        // Multiply the player's y local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    public IEnumerator RestartLevel()
    {
        screenWipe.WipeToBlack();
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
