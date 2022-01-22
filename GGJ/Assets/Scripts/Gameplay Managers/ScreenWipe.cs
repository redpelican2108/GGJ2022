using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWipe : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {

    }

    public void WipeToBlack()
    {
        animator.SetTrigger("FadeToBlack");
    }
}
