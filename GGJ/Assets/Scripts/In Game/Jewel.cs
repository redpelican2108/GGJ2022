using UnityEngine;

public class Jewel : MonoBehaviour
{
    private Portal exit = null;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    public BoxCollider2D _collider;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Portal" && exit == null)
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

        if (collision.tag == "Tornado")
        {
            collision.GetComponent<Tornado>().StartCount();
            Destroy(this.gameObject);
        }

        if (collision.tag == "Gravity")
        {
            Physics2D.gravity = new Vector3(0f, -9.81f, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Portal" && exit == collision.GetComponent<Portal>())
        {
            
            exit = null;
        }

        if (collision.tag == "Button")
        {
            collision.GetComponent<GameButton>().Press(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Skull"))
        {
            Destruct();
        }
    }
    public void Destruct()
    {
        StartCoroutine(playerMovement.RestartLevel());

        // TODO: Animation and sound of breaking
        // DONT BREAK THIS YET!!!
        //Destroy(this.gameObject);
    }

    public void PickUp()
    {
        Destroy(this.gameObject);
    }
}
