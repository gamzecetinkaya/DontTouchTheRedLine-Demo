using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject quitButton;
    public GameObject howToPlayPanel;
    

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShowMenu();
        }
        else 
        {
            HideMenu();
        }

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(); 
        }
    }

    public void StartGame()
    {
        HideMenu();
        ResumeGame();
    }

    public void ShowHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);

        }
        
        playButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
        playButton.SetActive(true);
        howToPlayButton.SetActive(true);
        quitButton.SetActive(true);
        ShowMenu();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void ShowMenu()
    {
        playButton.SetActive(true);
        howToPlayButton.SetActive(true);
        quitButton.SetActive(true);
        howToPlayPanel.SetActive(false);
        PauseGame();
    }

    public void HideMenu()
    {
        playButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
        howToPlayPanel.SetActive(false);
    }

    private void ToggleMenu()
    {
        if (playButton.activeSelf)
        {
            HideMenu();
            ResumeGame();
        }
        else
        {
            ShowMenu();
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
