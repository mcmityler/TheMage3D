using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Written by: Tyler McMillan
 * Decription: Torch that takes the player from the level back to main level. and saves if you beat the level
 */
public class TorchReturn : MonoBehaviour
{
    //Torch Materials
    public Material[] topMat;
    public Material[] middleMat;
    public GameObject topTorch;
    public GameObject middleTorch;
    Renderer topTorchRend;
    Renderer middleTorchRend;
    //Reference to player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Get render to change material
        topTorchRend = topTorch.GetComponent<Renderer>();
        middleTorchRend = middleTorch.GetComponent<Renderer>();
        //Make material default mat
        topTorchRend.sharedMaterial = topMat[0];

    }
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        //Change colour of mat if hit with fireball
        if (collision.gameObject.tag == "Fireball")
        {
            //Change color
            ChangeTorchColor();
            //Check what level you are beating
            CheckTorch();
            
            //Returning to main world
            player.GetComponent<PlayerInfo>().returning = true;
            //Save players coins and whether they beat it and are returning
            player.GetComponent<PlayerInfo>().piSaveInfo();
            //Return to last loaded scene
            string sceneName = PlayerPrefs.GetString("lastLoadedScene");
            SceneManager.LoadScene(sceneName);

        }
        else if (collision.gameObject.tag == "Fireball")
        {
            ChangeTorchColor();
        }
    }

    void ChangeTorchColor()
    {
        topTorchRend.sharedMaterial = topMat[1];
        middleTorchRend.sharedMaterial = middleMat[0];
    }
    void CheckTorch()
    {
        if (this.tag == "levelOne")
        {
            player.GetComponent<PlayerInfo>().lvl1Complete = true;
        }
        if (this.tag == "levelTwo")
        {
            player.GetComponent<PlayerInfo>().lvl2Complete = true;
        }
        if (this.tag == "levelThree")
        {
            player.GetComponent<PlayerInfo>().lvl3Complete = true;
        }
        if (this.tag == "levelFour")
        {
            player.GetComponent<PlayerInfo>().lvl4Complete = true;
        }
        if (this.tag == "levelFive")
        {
            player.GetComponent<PlayerInfo>().lvl5Complete = true;
        }
        if (this.tag == "levelSix")
        {
            player.GetComponent<PlayerInfo>().lvl6Complete = true;
        }
        if (this.tag == "levelSeven")
        {
            player.GetComponent<PlayerInfo>().lvl7Complete = true;
        }
        if (this.tag == "levelEight")
        {
            player.GetComponent<PlayerInfo>().lvl8Complete = true;
        }
        if (this.tag == "levelNine")
        {
            player.GetComponent<PlayerInfo>().lvl9Complete = true;
        }
        if (this.tag == "levelTen")
        {
            player.GetComponent<PlayerInfo>().lvl10Complete = true;
        }
    }
}
