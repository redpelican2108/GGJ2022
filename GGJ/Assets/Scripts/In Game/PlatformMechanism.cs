using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMechanism : Mechanism
{
    [SerializeField] private bool movingToGreen;
    [SerializeField] private float speed;
    public Transform green, yellow, platform;
    private Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        if(movingToGreen)
        {
            destination = green.position;
        } else
        {
            destination = yellow.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (Vector2.Distance(platform.position, destination) < 0.1f)
            {
                if (movingToGreen)
                {
                    destination = yellow.position;
                    movingToGreen = false;
                }
                else
                {
                    destination = green.position;
                    movingToGreen = true;
                }
            }
            platform.position = Vector2.MoveTowards(platform.position, destination, speed);
        }
    }

    public override void OneTime()
    {
        if (movingToGreen)
        {
            destination = green.position;
            movingToGreen = false;
        }
        else
        {
            destination = yellow.position;
            movingToGreen = true;
        }
        StartCoroutine(Move());
        
    }

    IEnumerator Move()
    {
        while (Vector2.Distance(platform.position, destination) > 0.1f)
        {
            platform.position = Vector2.MoveTowards(platform.position, destination, speed);
            yield return null;
        }
    }
}
