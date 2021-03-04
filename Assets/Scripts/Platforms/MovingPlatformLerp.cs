using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by: Tyler McMillan
 * Decription: moves platfrom
 *     Has:
 *      Moves platform from pos 1 to 2 with a lerp. 
 *  
 */
public class MovingPlatformLerp : MonoBehaviour
{
    //platform transform.
    public Transform movingPlatform;
    //first destination
    public Transform position1;
    //second destination
    public Transform position2;
    //position it is moving to 
    public Vector3 newPosition;
    //Display what position its moving to 
    public string currentState;
    //smoothness of the platform
    public float smooth;
    //how long till it resets
    public float resetTime;
    //time it is currently at before it resets
    private float _time = 0;

    //Array for platforms Materials
    public Material[] platMaterial;
    //Access to renderer
    Renderer materialRenderer;

    //Has the platform changed direction
    bool changeDir = true;
    //Arrow object
    public GameObject arrow;
    //how much time to warn the player (percentage of reset time)
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
        //Warn the player it is changing directions
        if (resetTime >= 2 && _time >= resetTime - resetTime * warningTime && changeDir)
        {
            materialRenderer.sharedMaterial = platMaterial[platMaterial[0] == materialRenderer.sharedMaterial ? 1 : 0];
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
        //move position of platform
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
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
