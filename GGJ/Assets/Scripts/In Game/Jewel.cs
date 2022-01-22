using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    private Portal exit = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Portal" && exit == null)
        {
            exit = collision.GetComponent<Portal>().other;
            transform.position = exit.transform.position;
        }

        if (collision.tag == "Button")
        {
            collision.GetComponent<GameButton>().Press();
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
            collision.GetComponent<GameButton>().Press();
        }
    }

    public void Destruct()
    {
        Destroy(this.gameObject);
    }
}
