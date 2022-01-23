using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    public Vector2 target;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = target - (Vector2)transform.position;
        transform.right = direction;
        rb.velocity = direction.normalized * speed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("MovingPlatform"))
        {
            Destroy(this.gameObject);
        }
    }
}
