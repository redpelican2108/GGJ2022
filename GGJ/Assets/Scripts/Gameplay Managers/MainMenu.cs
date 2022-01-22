using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectScreen;
    public bool isLevelSelectScreenActive;
    private ScreenWipe screenWipe;

    private void Start()
    {
        isLevelSelectScreenActive = false;
        screenWipe = GameObject.FindGameObjectWithTag("ScreenWipe").GetComponent<ScreenWipe>();
    }
    public void PlayGame()
    {
        StartCoroutine(ActuallyPlayGame(11));
    }

    public IEnumerator ActuallyPlayGame(int sceneNumber)
    {
        // Play Screen Wipe
        screenWipe.WipeToBlack();

        // Wait for 1 Second
        yield return new WaitForSeconds(1);

        // Load Next Scene
        SceneManager.LoadScene(sceneNumber);
    }

    public void ToggleLevelSelectScreen()
    {
        if (!isLevelSelectScreenActive)
        {
            levelSelectScreen.SetActive(true);
        }
        else
        {
            levelSelectScreen.SetActive(false);
        }

        isLevelSelectScreenActive = !isLevelSelectScreenActive;
    }

    public void GoToLevel(int level)
    {
        StartCoroutine(ActuallyPlayGame(level));
    }
}
