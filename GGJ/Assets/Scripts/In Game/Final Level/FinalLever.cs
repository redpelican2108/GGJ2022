using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLever : MonoBehaviour
{
    public bool isOn;
    public Sprite[] sprites; // 0 is off, 1 is on
    public CodeManager codeManager;
    private SpriteRenderer spriteRenderer;
    private bool isActivated;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActivated)
        {
            Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = false;
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
