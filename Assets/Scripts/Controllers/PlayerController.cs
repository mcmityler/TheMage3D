using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 * Written by: Tyler McMillan
 * Decription: Purpose is the movement of the player and physics.
 */
public class PlayerController : MonoBehaviour
{

    //Players movement speed
    public float pMoveSpeed;
    //normal movement speed (incase change speed)
    private float _pNormalSpeed;
    //Players jump force
    public float pJumpForce;
    //Player character controller
    public CharacterController pController;
    //Movement direction
    private Vector3 pMoveDir;
    //Gravity
    public float gravityScale;
    //checks if player jumped (when player presses space)
    public bool pJumped = false;
    //Where the player spawns in the level
    public GameObject pSpawnPoint;
    //Players velocity
    public Vector3 pVelocity;
    //Max speed the player can move
    public float pMaxMoveSpeed = 10;
    //Players deceleration speed when moving
    public float pDeceleration = 0.9f;
    //debuff to players movement when in air
    public float inAirDebuff = 0.8f;
    //is the player supposed to return to spawnpoint
    public bool pReturnToSpawn = false;

    // Use this for initialization
    void Start()
    {
        //Get CharacterController from what script is attatched to. which is the player
        pController = GetComponent<CharacterController>();
        //Set the normal movement speed to a private variable incase you change it 
        _pNormalSpeed = pMoveSpeed;

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //temp hold for move direction for y 
        float yTemp = pMoveDir.y;

        //set new move direction
        pMoveDir = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));

        //Move player based on player speed
        pMoveDir = pMoveDir.normalized * pMoveSpeed;
       
        //set y back to original
        pMoveDir.y = yTemp;

        //Makes sure player is on ground so you cant jump multiple times
        if (pController.isGrounded)
        {
            //set yvel to 0 if on ground so it doesnt snap when you fall.
            pMoveDir.y = 0f;

            //Jump force
            if (pJumped)
            {
                pMoveDir.y = pJumpForce;
                pJumped = false;
            }

        }

        //Adding gravity
        pMoveDir.y = pMoveDir.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        //Debuff for moving in air
        if (pController.isGrounded)
        {
            //Add velocity 
            pVelocity += pMoveDir * Time.deltaTime;
        }
        if (!pController.isGrounded)
        {
            //Add velocity 
            pVelocity += pMoveDir * Time.deltaTime * inAirDebuff;
        }


       

        //Decelleration
        pVelocity *= pDeceleration;
    }
    void Update()
    {
        
        //Cap teh velocity of the player.
        pVelocity = new Vector3(pVelocity.x < pMaxMoveSpeed ? pVelocity.x : pMaxMoveSpeed, 0, pVelocity.z < pMaxMoveSpeed ? pVelocity.z : pMaxMoveSpeed);
        
        //Move player in game based off of velocity
        pController.Move(new Vector3(pVelocity.x, pMoveDir.y * Time.deltaTime, pVelocity.z));
        

        //teleport player back to spawn point.
        if (pReturnToSpawn)
        {
            transform.position = pSpawnPoint.transform.position;
            pReturnToSpawn = false;
        }
    }

    //Call function to return player to its spawn point
    public void ReturnToSpawnPoint()
    {
        pReturnToSpawn = true;
    }

    //---------Save & Load --------
    //Save players Info
    public void pcSavePlayer()
    {

        SavePlayerController.SavePC(this);

    }
    //Load Players Info
    public void pcLoadPlayer()
    {
        PCData data = SavePlayerController.LoadPC();

        if(data!= null)
        {
            Vector3 _position;
            _position.x = data.pcPosition[0];
            _position.y = data.pcPosition[1];
            _position.z = data.pcPosition[2];
            this.transform.position = _position;
        }
    }
    //Reset player controllers data when starting a new game
    public void resetPlayerController()
    {
        transform.position = pSpawnPoint.transform.position;
        pcSavePlayer();
    }



}
