using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by: Tyler McMillan
 * Decription: Sets player as the platforms child
 * 
 */
public class PlayerToPlatform : MonoBehaviour
{
    //if player enters trigger set it as a child
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.transform.parent = gameObject.transform.parent;

        }
    }
    //if player enters trigger set it as a child
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            col.transform.parent = null;

        }
    }
}
