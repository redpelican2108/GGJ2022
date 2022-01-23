using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGroup : MonoBehaviour
{
    public Lever[] levers;
    [SerializeField] private bool[] combination;
    public Mechanism mechanism;

    public void Check()
    {
        for(int i = 0; i < levers.Length; i++)
        {
            if(combination[i] ^ levers[i].on)
            {
                return;
            }
        }
        mechanism.OneTime();
    }
}
