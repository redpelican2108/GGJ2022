using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public Mechanism mechanism;
    [SerializeField] private bool oneTime;
    [SerializeField] private bool destroyOnPush;

    public void Press(bool enter)
    {
        if(mechanism == null)
        {
            Destroy(this.gameObject);
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
        
        if(destroyOnPush)
        {
            Destroy(this.gameObject);
        }
    }
}
