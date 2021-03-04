using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int amount = 1;
    //When player collides with coin, collects
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerInfo>().CollectCoins(amount);
            gameObject.SetActive(false);

        }
    }
}
