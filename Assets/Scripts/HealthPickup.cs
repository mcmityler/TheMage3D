using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public void OnTriggerStay(Collider col)
    {
        //When hit with fireball start a timer and until platform disappears again, maybe changes alpha back
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<PlayerInfo>().AddHealth();
            Destroy(gameObject);
        }
    }
}
