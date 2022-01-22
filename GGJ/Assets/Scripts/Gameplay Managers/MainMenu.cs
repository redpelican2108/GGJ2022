using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectScreen;
    public bool isLevelSelectScreenActive;

    private void Start()
    {
        isLevelSelectScreenActive = false;
    }
    public void PlayGame()
    {
        Debug.Log("ioeho");
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
        SceneManager.LoadScene(level);
    }
}
