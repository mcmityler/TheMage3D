using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Key : MonoBehaviour
{
    public GameObject player;
    private bool _beatlevel1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _beatlevel1 = player.GetComponent<PlayerInfo>().lvl1Complete;
        if (_beatlevel1)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
