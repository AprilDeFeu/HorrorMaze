using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MainMenu
{
    public GameObject endScreen;
    public GameObject player;
    void OnTriggerEnter ()
    {
        CompleteLevel();
    }

    

    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    } 
    public void CompleteLevel ()
    {
        Debug.Log("Endzone Reached.");
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

}
