using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool on;
    private LeverGroup lg;
    private bool canInteract;
    private SpriteRenderer sp;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        canInteract = false;
        sp = GetComponent<SpriteRenderer>();
        lg = GetComponentInParent<LeverGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.F))
        {
            on = !on;
            if(on)
            {
                sp.sprite = sprites[0];
            } else
            {
                sp.sprite = sprites[1];
            }
            lg.Check();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
