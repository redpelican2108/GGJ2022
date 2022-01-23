using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float minPower;
    [SerializeField] private float maxPower;
    public GameObject jewelOnHead;
    public GameObject jewel;
    public GameObject point;
    [SerializeField] private int pointNumber;
    public GameObject[] points;
    private BoxCollider2D _collider;
    private Rigidbody2D rb;
    private Jewel jewelToPick;
    private bool aiming;
    public bool pickJewel;
    public bool hasJewel;
    
    // Start is called before the first frame update
    private void Start()
    {
        hasJewel = true;
        pickJewel = false;
        aiming = false;
        points = new GameObject[pointNumber];
        _collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        for(int i = 0; i < pointNumber; i++)
        {
            points[i] = Instantiate(point, transform.position, Quaternion.identity);
            points[i].SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickJewel)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                jewelToPick.PickUp();
                jewelToPick = null;
                hasJewel = true;
                jewelOnHead.SetActive(true);
                pickJewel = false;
            }
        }
        else if (hasJewel)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 10f);
                if (hit.collider != null && hit.collider.Equals(_collider))
                {
                    aiming = true;
                    foreach (GameObject point in points)
                    {
                        point.SetActive(true);
                    }

                }
            }

            if (aiming)
            {
                for (int i = 0; i < pointNumber; i++)
                {
                    points[i].transform.position = PointPosition(i * 0.1f);
                }

                if (Input.GetMouseButtonDown(1))
                {
                    //Hide the trajectory
                    aiming = false;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    aiming = false;
                    Shoot(Aim());
                }

                if (!aiming)
                {
                    foreach (GameObject point in points)
                    {
                        point.SetActive(false);
                    }
                }
            }
        }
    }

    private Vector2 Aim()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2) transform.position - mousePos) * power;
        if(direction.magnitude < minPower)
        {
            return direction = direction.normalized * minPower;
        }
        return Vector2.ClampMagnitude(direction, maxPower);

    }

    private void Shoot(Vector2 direction)
    {

        GameObject shotJewel = Instantiate(jewel, transform.position, Quaternion.identity);
        shotJewel.GetComponent<Rigidbody2D>().velocity = direction;
        hasJewel = false;
        jewelOnHead.SetActive(false);
    }

    private Vector2 PointPosition(float time)
    {
        return (Vector2)transform.position + Aim() * time + 0.5f * Physics2D.gravity * time * time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal"))
        {
            if(collision.GetComponent<Portal>().oneTime)
            {
                GameObject shotJewel = Instantiate(jewel, collision.transform.position, Quaternion.identity);
                hasJewel = false;
                jewelOnHead.SetActive(false);
            }
        }
        if(collision.tag == "Jewel")
        {
            pickJewel = true;
            jewelToPick = collision.GetComponent<Jewel>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Jewel")
        {
            pickJewel = false;
        }
    }
}
