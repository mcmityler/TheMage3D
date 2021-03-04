using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by: Tyler McMillan
 * Decription: Collectable fireball scroll 
 */
public class FireballScroll : MonoBehaviour
{
    //When player enters trigger sets fireball scoll collected to true and also destroys scroll object
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Sets fireball scroll true on spell controller (what shoots the spells)
            collider.GetComponentInChildren<SpellController>().fireballScroll = true;
            //Sets fireball scroll true where it saves the fireball scroll
            collider.GetComponent<PlayerInfo>().FBScrollCollected = true;
            Object.Destroy(gameObject);
        }
    }
}
