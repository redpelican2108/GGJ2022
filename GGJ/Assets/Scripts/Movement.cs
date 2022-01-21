using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask platformMask;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private float xAxis;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

    }

    private void FixedUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xAxis * walkSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        float delta = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, delta, platformMask);
        return raycastHit.collider != null;
    }
}
