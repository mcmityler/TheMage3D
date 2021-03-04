using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Written by: Tyler McMillan
 * Decription: Purpose is to manage the controls of the player
 *     Has:
 *      Check players controls
 *     Want:
 *      dont know how to do it right now but would be nice if players wasd controls were in here rather than in the other function.
 *  
 */
public class Controls : MonoBehaviour
{
    //References to objects
    public GameObject player;
    public GameObject camObject;
    public GameObject spells;

    // Update is called once per frame
    void Update()
    {
        //Player Shooting 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (spells.GetComponent<SpellController>().fireballScroll)
            {
                spells.GetComponent<SpellController>().ShootFireBall();
            }
        }
        //Zoom in to player
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            camObject.GetComponent<CameraController>().ZoomIn();
        }
        //Zoom out of player
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            camObject.GetComponent<CameraController>().ZoomOut();
        }
        //Players Jump
        if (Input.GetButtonDown("Jump"))
        {
            player.GetComponent<PlayerController>().pJumped = true;
        }
        //Exits Application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Main Menu
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }
        //Save Game & make sure that you are in the overworld when doing so. 
        if (Input.GetKeyDown(KeyCode.P) && (SceneManager.GetActiveScene().buildIndex == 1))
        {
            player.GetComponent<PlayerController>().pcSavePlayer();
            player.GetComponent<PlayerInfo>().piSaveInfo();
        }
        //Interact with people and objects.
        if (Input.GetKeyDown(KeyCode.E))
        {
        }
    }
}
