using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject door;
    private void Start()
    {
        
    }
    private void Update()
    {
        // Restart the Level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        // TODO: Screen Wipe

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
