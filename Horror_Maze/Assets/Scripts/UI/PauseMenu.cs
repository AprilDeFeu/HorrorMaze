using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu
{
    public bool isBlocked = false;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    GameObject gameAudio;

    public void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        gameAudio = GameObject.FindGameObjectWithTag("Audio");
        Resume();
    }
    public void MainMenu() {
        
        SceneManager.LoadScene("MainMenu");
    } 
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isBlocked)
        {
            if (GameIsPaused) Resume();
            else Pause();
        } 
    }

    public void Resume()
    {
        if (gameAudio != null) gameAudio.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (gameAudio != null) gameAudio.SetActive(false);
    }
}
