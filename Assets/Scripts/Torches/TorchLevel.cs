using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Written by: Tyler McMillan
 * Decription: Torch that takes the player from the main level to another level
 */
public class TorchLevel : MonoBehaviour
{
    //Torch Materials
    public Material[] topMat;
    public Material[] middleMat;
    //Parts of torch that changes
    public GameObject topTorch;
    public GameObject middleTorch;
    Renderer topTorchRend;
    Renderer middleTorchRend;
    //Reference to player
    public GameObject player;
    //What level are you changing to
    public int nextLevel = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Get render to change material
        topTorchRend = topTorch.GetComponent<Renderer>();
        middleTorchRend = middleTorch.GetComponent<Renderer>();
        //Make material default mat
        topTorchRend.sharedMaterial = topMat[0];

    }
    //Check if the player already completed the level
    void Update()
    {
        updateTorches();
       
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        //Has a fireball hit a torch in scene 1
        if (collision.gameObject.tag == "Fireball" && (SceneManager.GetActiveScene().buildIndex == 1))
        {
            //Change color
            ChangeTorchColor();
            //Check that you are changing to a level above the scene you are on
            if (nextLevel > 1)
            {
                //Save players location
                player.GetComponent<PlayerController>().pcSavePlayer();
                //Changing level true than save it
                player.GetComponent<PlayerInfo>().changeLevel = true;
                player.GetComponent<PlayerInfo>().piSaveInfo();
                //Save what level the player was on previously
                PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
                //Transition to next level
                SceneManager.LoadScene(nextLevel);
            }
            

        }
        //Change torch to coloured
        else if (collision.gameObject.tag == "Fireball")
        {
            ChangeTorchColor();
        }
    }
    //Change colour of torch
    void ChangeTorchColor()
    {
        topTorchRend.sharedMaterial = topMat[1];
        middleTorchRend.sharedMaterial = middleMat[0];
    }
    void updateTorches()
    {
        if (player.GetComponent<PlayerInfo>().lvl1Complete)
        {
            if (this.tag == "levelOne")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl2Complete)
        {
            if (this.tag == "levelTwo")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl3Complete)
        {
            if (this.tag == "levelThree")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl4Complete)
        {
            if (this.tag == "levelFour")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl5Complete)
        {
            if (this.tag == "levelFive")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl6Complete)
        {
            if (this.tag == "levelSix")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl7Complete)
        {
            if (this.tag == "levelSeven")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl8Complete)
        {
            if (this.tag == "levelEight")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl9Complete)
        {
            if (this.tag == "levelNine")
            {
                ChangeTorchColor();
            }
        }
        if (player.GetComponent<PlayerInfo>().lvl10Complete)
        {
            if (this.tag == "levelTen")
            {
                ChangeTorchColor();
            }
        }
    }
}
