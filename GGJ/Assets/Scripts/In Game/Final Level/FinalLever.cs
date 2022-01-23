using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLever : MonoBehaviour
{
    public bool isOn;
    public Sprite[] sprites; // 0 is off, 1 is on
    public CodeManager codeManager;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.gameObject.CompareTag("Player"))
        {
            Interact();
        }
    }
    public void Interact()
    {
        if (!codeManager.puzzleSolved)
        {
            if (isOn)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                spriteRenderer.sprite = sprites[1];
            }

            isOn = !isOn;

            codeManager.CheckPuzzleSolved();
        }
    }
}
