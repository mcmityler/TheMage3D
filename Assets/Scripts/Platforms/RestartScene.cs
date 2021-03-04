using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    //Reference to player
    public GameObject player;

    //When player enters and stays in trigger it will return it to the spawn point
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().ReturnToSpawnPoint();
        }
    }
}
