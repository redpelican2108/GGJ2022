using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMechanism : Mechanism
{
    [SerializeField] private float maxScale;
    [SerializeField] private bool extended;
    [SerializeField] private bool inX;
    [SerializeField] private float currentScale = 1f;
    [SerializeField] private bool isOneTime;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(isOneTime)
        {
            return;
        }
        if(activated && currentScale < maxScale)
        {
            currentScale += .004f;
            if (inX)
            {
                transform.localScale = new Vector3(currentScale, 1, 1);
            } 
            else
            {
                transform.localScale = new Vector3(1, currentScale, 1);
            }
        } else if (!activated && currentScale > 1f)
        {
            currentScale -= .004f;
            if (inX)
            {
                transform.localScale = new Vector3(currentScale, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, currentScale, 1);
            }
        }
    }

    public override void OneTime()
    {
        if(extended)
        {
            StartCoroutine(Shrink());
        } else
        {
            StartCoroutine(Expand());
        }
    }

    IEnumerator Expand()
    {
        while (currentScale < maxScale)
        {
            currentScale += .004f;
            if (inX)
            {
                transform.localScale = new Vector3(currentScale, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, currentScale, 1);
            }
            yield return null;
        }
    }

    IEnumerator Shrink()
    {
        while (currentScale > 1)
        {
            currentScale -= .004f;
            if (inX)
            {
                transform.localScale = new Vector3(currentScale, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, currentScale, 1);
            }
            yield return null;
        }
    }
}
