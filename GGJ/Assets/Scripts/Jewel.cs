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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Portal" && exit == collision.GetComponent<Portal>())
        {
            exit = null;
        }
    }

    public void Destruct()
    {
        Destroy(this.gameObject);
    }
}
