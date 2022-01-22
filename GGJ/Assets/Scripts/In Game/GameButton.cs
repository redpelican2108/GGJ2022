using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public Mechanism mechanism;

    public void Press()
    {
        mechanism.Activate();
    }
}
