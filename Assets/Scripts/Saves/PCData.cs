using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Written by: Tyler McMillan
 * Decription: Purpose is storing the player controllers data
 */
[System.Serializable]
public class PCData
{
    //Variables you want your player to save
    public float[] pcPosition;

    //constructor data from player in variables
    public PCData(PlayerController player)
    {

        pcPosition = new float[3];
        pcPosition[0] = player.transform.position.x;
        pcPosition[1] = player.transform.position.y;
        pcPosition[2] = player.transform.position.z;
        
    }

}
