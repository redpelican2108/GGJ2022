using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject door;
    public GameObject pauseMenu;
    private PlayerMovement playerMovement;
    private bool isGamePaused;
    private ScreenWipe screenWipe;
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        screenWipe = GameObject.FindGameObjectWithTag("ScreenWipe").GetComponent<ScreenWipe>();

        isGamePaused = false;
    }
    private void Update()
    {
        // Restart the Level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Toggle pausing the Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!isGamePaused)
        {
            pauseMenu.SetActive(true);
            playerMovement.gamePaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            playerMovement.gamePaused = true;
        }

        isGamePaused = !isGamePaused;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        
        // Screen Wipe
        screenWipe.WipeToBlack();

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
