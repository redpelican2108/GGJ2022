using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private GameplayManager gameplayManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Throwing>().hasJewel && !other.GetComponent<PlayerMovement>().stageComplete)
            {
                other.GetComponent<PlayerMovement>().stageComplete = true;
                animator.SetTrigger("Open");
                StartCoroutine(gameplayManager.NextLevel());
            }
        }
    }
}
