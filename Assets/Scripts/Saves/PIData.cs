using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Written by: Tyler McMillan
 * Decription: Purpose is saving the players info
 */
[System.Serializable]
public class PIData
{
    //Coins
    public int piCoins = 0;
    //Are you loading back  in from a save
    public bool piLoadFromSave;
    //Have you collected the fireball scroll
    public bool piFBScroll;
    //Have you changed the level
    public bool piChangeLevel;
    //Have you beat level 1
    public bool piLvl1;
    public bool piLvl2;
    public bool piLvl3;
    public bool piLvl4;
    public bool piLvl5;
    public bool piLvl6;
    public bool piLvl7;
    public bool piLvl8;
    public bool piLvl9;
    public bool piLvl10;
    //Are you returning back to the main world
    public bool piReturning;

    //constructor data from player in variables
    public PIData(PlayerInfo player)
    {

        piCoins = player.coins;

        piLoadFromSave = player.LoadFromSave;

        piFBScroll = player.FBScrollCollected;

        piChangeLevel = player.changeLevel;

        piReturning = player.returning;

        piLvl1 = player.lvl1Complete;
        piLvl2 = player.lvl2Complete;
        piLvl3 = player.lvl3Complete;
        piLvl4 = player.lvl4Complete;
        piLvl5 = player.lvl5Complete;
        piLvl6 = player.lvl6Complete;
        piLvl7 = player.lvl7Complete;
        piLvl8 = player.lvl8Complete;
        piLvl9 = player.lvl9Complete;
        piLvl10 = player.lvl10Complete;



    }

}
