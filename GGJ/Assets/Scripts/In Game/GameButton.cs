using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public Mechanism mechanism;
    [SerializeField] private bool oneTime;

    public void Press(bool enter)
    {
        if(mechanism == null)
        {
            return;
        }
        if (!oneTime)
        {
            mechanism.Activate();
        } else
        {
            if (enter)
            {
                mechanism.OneTime();
            }
        }
    }
}
