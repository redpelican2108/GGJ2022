using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public List<string> lst;
    public GameObject canvas;
    public TMP_Text displayText;
    public PlayerMovement playerMovement;
    private Queue<string> queue = new Queue<string>();
    private bool completeDialogue;

    private void Start()
    {
        for (int i = 0; i < lst.Count; i++)
        {
            queue.Enqueue(lst[i]);
        }
        canvas.SetActive(true);
        NextLine();

        playerMovement.stageComplete = true;
    }

    private void Update()
    {
        if (!completeDialogue && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    private void NextLine()
    {
        if (queue.Count != 0)
        {
            string temp = queue.Dequeue();
            displayText.text = temp;
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        canvas.SetActive(false);
        playerMovement.stageComplete = false;
    }
}
