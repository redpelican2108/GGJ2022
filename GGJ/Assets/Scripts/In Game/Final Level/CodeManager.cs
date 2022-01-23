using System.Collections;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    public FinalLever[] finalLevers;
    public AudioClip audioClip;
    public Animator animator;
    public bool puzzleSolved;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void CheckPuzzleSolved()
    {
        if (!finalLevers[0].isOn && finalLevers[1].isOn && !finalLevers[2].isOn && !finalLevers[3].isOn && finalLevers[4].isOn)
        {
            puzzleSolved = true;
            StartCoroutine(UnlockDoor());
        }
    }

    public IEnumerator UnlockDoor()
    {
        audioSource.PlayOneShot(audioClip);
        animator.SetTrigger("OpenDoor");
        yield return new WaitForSeconds(1);
        Destroy(animator.gameObject);
    }
}
