using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMechanism : Mechanism
{
    public override void OneTime()
    {
        Destroy(this.gameObject);
    }
}
