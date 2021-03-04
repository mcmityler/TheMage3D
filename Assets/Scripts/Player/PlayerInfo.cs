using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    //Amount of Coins Collected
    public int coins = 0;
    //Coin Text
    public Text coinText;

    //Save if FB scroll was collected
    public bool FBScrollCollected = false;

    //Load from save
    public bool LoadFromSave;

    public int health = 3;

    public bool changeLevel;

    public bool lvl1Complete; 
    public bool lvl2Complete; 
    public bool lvl3Complete; 
    public bool lvl4Complete; 
    public bool lvl5Complete; 
    public bool lvl6Complete; 
    public bool lvl7Complete; 
    public bool lvl8Complete; 
    public bool lvl9Complete; 
    public bool lvl10Complete; 


    public bool returning;

    //Heart Images for health
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;

    public AudioClip pickupSound;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 1)
        {
            LoadGame();
        }

        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Update current health
        updateHealth();
        
        //Display Coins
        if(coinText != null)
        {
            coinText.text = " x " + coins;
        }
        //If fireball scroll was collected and you saved (set it to true in spell controller)
        if (FBScrollCollected)
        {
            GetComponentInChildren<SpellController>().fireballScroll = true;
        }
    }

    //Collect Coin Function
    public void CollectCoins(int val)
    {
        coins += val;

        audio.PlayOneShot(pickupSound);
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }



    //---------Save & Load --------
    //Save players Info
    public void piSaveInfo()
    {

        Debug.Log("Saved");
        SavePlayerInfo.SavePI(this);

    }
    //Load Players Info
    public void piLoadInfo()
    {
        PIData data = SavePlayerInfo.LoadPI();
        if (data != null)
        {
            coins = data.piCoins;
            FBScrollCollected = data.piFBScroll;
            lvl1Complete = data.piLvl1;
            lvl2Complete = data.piLvl2;
            lvl3Complete = data.piLvl3;
            lvl4Complete = data.piLvl4;
            lvl5Complete = data.piLvl5;
            lvl6Complete = data.piLvl6;
            lvl7Complete = data.piLvl7;
            lvl8Complete = data.piLvl8;
            lvl9Complete = data.piLvl9;
            lvl10Complete = data.piLvl10;
            piSaveInfo();
        }
        
    }
    //checks if player has a save file to load
    void LoadGame()
    {
        PIData data = SavePlayerInfo.LoadPI();
        if (data != null)
        {
            LoadFromSave = data.piLoadFromSave;
            changeLevel = data.piChangeLevel;
            returning = data.piReturning;
            //Loading from save file
            if (LoadFromSave)
            {
                LoadFromSave = false;
                piLoadInfo();
                GetComponentInParent<PlayerController>().pcLoadPlayer();
            }
            //Load coins and what scrolls you have when entering a new level
            if (changeLevel)
            {
                changeLevel = false;
                piLoadInfo();
                Debug.Log("loaded");
            }
            //If returning from a level back to main world
            if (returning)
            {
                returning = false;
                piLoadInfo();
                GetComponentInParent<PlayerController>().pcLoadPlayer();
            }
        }
        
    }

    //Reset player info on starting a new game
    public void resetSaveInfo()
    {
        LoadFromSave = false;
        coins = 0;
        piSaveInfo();

    }
    public void AddHealth()
    {
        if(health <= 5)
        {
            health++;
        }
    }

    //Updates health on screen, also resets health and returns player to spawn point when player "dies"
    void updateHealth()
    {
        if (heart1 != null)
        {
            if (health == 5)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                heart4.enabled = true;
                heart5.enabled = true;
            }
            if (health == 4)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                heart4.enabled = true;
                heart5.enabled = false;
            }
            if (health == 3)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                heart4.enabled = false;
                heart5.enabled = false;
            }
            else if (health == 2)
            {
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
                heart4.enabled = false;
                heart5.enabled = false;
            }
            else if (health == 1)
            {
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
                heart4.enabled = false;
                heart5.enabled = false;
            }
            else if (health <= 0)
            {
                health = 3;
                this.GetComponent<PlayerController>().ReturnToSpawnPoint();
            }
        }
    }
}
