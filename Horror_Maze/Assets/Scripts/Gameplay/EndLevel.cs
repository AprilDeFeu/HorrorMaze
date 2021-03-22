using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MainMenu
{
    public GameObject endScreen;
    public GameObject player;
    
    bool hasWon = false;

    void Start() 
    {
        hasWon = false;
    }
    void OnTriggerEnter ()
    {
        CompleteLevel();
        
    }

    void Update()
    {
        if (hasWon) GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenu>().isBlocked = true;
    }
    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    } 
    public void CompleteLevel ()
    {
        GameObject.FindGameObjectWithTag("Audio").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Audio").transform.GetChild(1).gameObject.SetActive(false);
        hasWon = true;
        Debug.Log("Endzone Reached.");
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

}
