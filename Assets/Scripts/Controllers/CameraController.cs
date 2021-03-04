using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Written by: Tyler McMillan
 * Decription: Purpose is the movement of the camera
 *     Has:
 *      Follows player
 *      Camera hit detection (walls wont obstruct views)
 *     Want:
 *      - move camera while holding shift or key to move camera pivot (so you can see the front of the player)
 *  
 */

public class CameraController : MonoBehaviour
{

    //Players Transform, what the camera is focused at
    public Transform cameraTarget;
    //How far the camera is from its target
    public Vector3 camOffset;
    //Toggle offset on/off
    public bool useCamOffset;
    //How fast you can rotate the camera
    public float camRotateSpeed;
    //Center pivot that camera turns on
    public Transform camPivot;

    //Max angle up you can go
    public float maxViewAngle;
    //Max angle down you can go
    public float minViewAngle;
    //Inverts camera controls (y)
    public bool invertY;
    //Layer that the walls have to be under to collide with camera
    public LayerMask wallLayer;
    //distance to add to camera when colliding with object
    public float collideDistance;


    //on start of function 
    void Start()
    {
        //if you arent using the offset set its offset to cameras current position
        if (!useCamOffset)
        {
            camOffset = cameraTarget.position - transform.position;
        }
        //Set pivot point
        camPivot.transform.position = cameraTarget.transform.position;
        //gives cam pivot parent to target
        camPivot.transform.parent = cameraTarget.transform;

        //Lock cursor to centre of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //Calculate how much to rotate the camera in the X direction
        float horizontal = Input.GetAxis("Mouse X") * camRotateSpeed;
        cameraTarget.Rotate(0, horizontal, 0);

        //Calculate how much to rotate the camera in the Y direction
        //Get Y position of mouse and rotate pivot
        float vertical = Input.GetAxis("Mouse Y") * camRotateSpeed;

        if (invertY)
        {
            camPivot.Rotate(vertical, 0, 0);
        }
        else
        {
            camPivot.Rotate(-vertical, 0, 0);
        }

        //Limit up/down camera rotation
        if (camPivot.rotation.eulerAngles.x > maxViewAngle && camPivot.rotation.eulerAngles.x < 180)
        {
            camPivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (camPivot.rotation.eulerAngles.x > 180 && camPivot.rotation.eulerAngles.x < 360 + minViewAngle)
        {
            camPivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //move camera based on current rotation of the camera target and offset.
        float desiredYAngle = cameraTarget.eulerAngles.y;
        float desiredXAngle = camPivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = cameraTarget.position - (rotation * camOffset);

        //if I want camera to stop at a specific y elevation below the camera target
        // if(transform.position.y < cameraTarget.position.y)
        //{
        //    transform.position = new Vector3(transform.position.x, cameraTarget.position.y - 0.1f, transform.position.z);
        //}

        transform.LookAt(cameraTarget);

        CheckWall();

    }

    //Collision for walls
    void CheckWall()
    {
        //Create raycast to check if collision
        RaycastHit hit;
        //start point of ray cast
        Vector3 start = cameraTarget.position;
        //direction of raycast
        Vector3 dir = transform.position - cameraTarget.position;
        //Distance from player to camera
        float dist = camOffset.z + 2;
         //dist = camOffset.z <= 4 ? camOffset.z : dist;
        //Draw ray to see in scene view
        Debug.DrawRay(cameraTarget.position, dir, Color.green);
        //Collision of raycast to wall layer
        if (Physics.Raycast(cameraTarget.position, dir, out hit, dist, wallLayer))
        {
            //set hit distance
            float hitDist = hit.distance;
            //get distance to set camera
            Vector3 sphereCastCenter = cameraTarget.position + (dir.normalized * hitDist);
            //set camera to calculated distance
            transform.position = sphereCastCenter;
        }
    }
    //Function for camera to zoom in (called using + key in conrols)
    public void ZoomIn()
    {
        //Check what distance zoom is at to make sure you cant mess up camera
        if(camOffset.z > 6)
        {
            camOffset.z -= 1;
            camOffset.y += 1;
        }
        else if (camOffset.z > 2)
        {
            camOffset.z -= 1;
            camOffset.y += 1;
            maxViewAngle -= 10;
        }
        else if(camOffset.z > 1)
        {
            camOffset.z -= 1;
            camOffset.y += 1;
        }
    }
    //Zoom out camera( called using - key in conrols)
    public void ZoomOut()
    {
        //Check what distance zoom is at to make sure you cant mess up camera
        if (camOffset.z < 2)
        {
            camOffset.z += 1;
            camOffset.y -= 1;
        }
        else if (camOffset.z < 6)
        {
            camOffset.z += 1;
            camOffset.y -= 1;
            maxViewAngle += 10;
        }
        else if (camOffset.z < 10)
        {
            camOffset.z += 1;
            camOffset.y -= 1;
        }
    }
}
