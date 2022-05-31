using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI, aboutDialog;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
        
    }

    public void showAboutDialog()
    {
        aboutDialog.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void closeAboutDialog()
    {
        aboutDialog.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        Time.timeScale = 0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void NewGame()
    {
        SaveSystem.ClearGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
