using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    bool invincible = false;
    float invCount = 0;

    public Transform position1;
    //second destination
    public Transform position2;
    //position it is moving to 
    public Vector3 newPosition;
    //Display what position its moving to 
    public string currentState;
    //smoothness of the platform
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Change target
        ChangeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        invCount -= Time.deltaTime;
        if(invCount <= 0)
        {
            invincible = false;
        }
        //move position of platform to next postion
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPosition, speed * Time.deltaTime);
        //check if it has reached new position
        if (gameObject.transform.position == newPosition)
        {
           
                
                 
                    ChangeTarget();
             


        }
    }

    //When player collides with coin, collects
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && !invincible)
        {
            Debug.Log("collide");
            invincible = true;
            invCount = 3;
            col.GetComponent<PlayerInfo>().TakeDamage(1);
            

        }
        if (col.tag == "Fireball" )
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
    //Change the target it is moving to 
    void ChangeTarget()
    {
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }

    }
}
