using UnityEngine;

public class CodeManager : MonoBehaviour
{
    public FinalLever[] finalLevers;
    public AudioClip audioClip;
    public Animator animator;
    public bool puzzleSolved;
    private AudioSource audioSource;

    public void CheckPuzzleSolved()
    {
        if (!finalLevers[0] && finalLevers[1] && !finalLevers[2] && !finalLevers[3] && finalLevers[4])
        {
            puzzleSolved = true;
        }
    }

    public void UnlockDoor()
    {
        audioSource.PlayOneShot(audioClip);
        animator.SetTrigger("OpenDoor");
    }
}
