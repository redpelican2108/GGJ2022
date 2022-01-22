using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMechanism : Mechanism
{
    [SerializeField] private float maxScale;
    public float currentScale = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(activated && currentScale < maxScale)
        {
            currentScale += .001f;
            transform.localScale = new Vector3(currentScale, 1, 1);
        } else if (!activated && currentScale > 1f)
        {
            currentScale -= .001f;
            transform.localScale = new Vector3(currentScale, 1, 1);
        }
    }

    public override void Activate()
    {
        activated = !activated;
    }

}
