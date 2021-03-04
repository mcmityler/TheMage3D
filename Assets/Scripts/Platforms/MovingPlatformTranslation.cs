using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by: Tyler McMillan
 * Decription: moves platfrom
 *     Has:
 *      Moves platform from pos 1 to 2 with translation. 
 *      Warns the player the platform is going to turn
 *  
 */
public class MovingPlatformTranslation : MonoBehaviour
{
    //platform transform.
    public GameObject movingPlatform;
    //first destination
    public Transform position1;
    //second destination
    public Transform position2;
    //position it is moving to 
    public Vector3 newPosition;
    //Display what position its moving to 
    public string currentState;
    //smoothness of the platform
    public float speed;
    //how long till it resets
    public float resetTime;
    //time it is currently at before it resets
    private float _time = 0;

    //Array for platforms Materials
    public Material[] platMaterial;
    //Access to renderer
    Renderer materialRenderer;

    //Has the platform changed directions
    bool changeDir = true;

    //Arrow object on the top of the platform / if it has one
    public GameObject arrow;

    //How much time should it give the player before it changed (percent of reset time)
    public float warningTime = 0.1f;


    // Use this for initialization
    void Start()
    {
        //Get material renderer from child object
        materialRenderer = movingPlatform.GetComponentInChildren<Renderer>();
        //Set default colour
        materialRenderer.sharedMaterial = platMaterial[0];
        //Change target
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move position of platform to next postion
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, newPosition, speed * Time.deltaTime);
        //check if it has reached new position
        if(movingPlatform.transform.position == newPosition)
        {
            //Check if it has a reset time
            if (resetTime > 0) {
                //Warn the player the platform is going to trun
                if (resetTime >= 2 && _time >= resetTime - resetTime * warningTime && changeDir)
                {
                    //Change colour
                    materialRenderer.sharedMaterial = platMaterial[platMaterial[0] == materialRenderer.sharedMaterial ? 1 : 0];
                    //Change arrow rotation if there is one
                    if (arrow != null)
                    {
                        arrow.transform.Rotate(new Vector3(0, 1, 0), 180);
                    }
                    changeDir = false;
                }
                if (_time >= resetTime)
                {
                    ChangeTarget();
                    _time = 0;
                    changeDir = true;
                }
                _time += Time.deltaTime;
            }
            //If it doesnt have a reset time bounce back imediately
            else
            {
                materialRenderer.sharedMaterial = platMaterial[platMaterial[0] == materialRenderer.sharedMaterial ? 1 : 0];
                if(arrow != null)
                {
                    arrow.transform.Rotate(new Vector3(0, 1, 0), 180);
                }
                ChangeTarget();
            }

               
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
