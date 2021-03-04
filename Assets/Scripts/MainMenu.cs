using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Written by: Tyler McMillan
 * Decription: Main menu Screen
 */
public class MainMenu : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        //Lock cursor to centre of screen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NewGame()
    {
        //Reset pc
        player.GetComponent<PlayerController>().resetPlayerController();
        
        //Reset info
        player.GetComponent<PlayerInfo>().resetSaveInfo();
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        //Load old player info
        player.GetComponent<PlayerInfo>().piLoadInfo();
        //Set player infos load from save value to true
        player.GetComponent<PlayerInfo>().LoadFromSave = true;
        //Save new info
        player.GetComponent<PlayerInfo>().piSaveInfo();
        //Load main world scene
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
