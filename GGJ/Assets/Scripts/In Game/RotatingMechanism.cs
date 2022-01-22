using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMechanism : Mechanism
{
    public GameObject[] platforms;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    [SerializeField] private bool clockwise;
    private float x;
    private float y;
    private float angle = 0f;

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            angle += 0.0001f * speed;
        } else
        {
            angle -= 0.0001f * speed;
        }
        if(angle > 360)
        {
            angle -= 360;
        } else if ( angle < 0)
        {
            angle += 360;
        }
        x = radius * Mathf.Cos(angle);
        y = radius * Mathf.Sin(angle);

        platforms[0].transform.position = (Vector2)transform.position + new Vector2(x, y);
        platforms[1].transform.position = (Vector2)transform.position - new Vector2(x, y);
    }
}
