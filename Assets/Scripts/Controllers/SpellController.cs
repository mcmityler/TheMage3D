using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    //Top of staff to change colours
    public GameObject centerCrystal;
    public GameObject glowCrystal;
    //Renderers
    Renderer centerCrystalRenderer;
    Renderer glowCrystalRenderer;

    //--------Colors----------
    public Material[] noSpellMat;
    public Material[] fireMat;

    //------------Scrolls---------------
    //fireball scroll
    public bool fireballScroll = false;


    //----------FireBall---------------
    //fireball itself
    public GameObject fireball;
    //fireball speed
    public float fireballSpeed = 100f;
    //fireball timer (make sure you cant spam fire balls, but can hold down)
    private float _fireballTime = 0;
    //Fireball fire rate in seconds
    public float fireballFireRate = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        //Get renderers (things im changing the colour of
        centerCrystalRenderer = centerCrystal.GetComponent<Renderer>();
        glowCrystalRenderer = glowCrystal.GetComponent<Renderer>();
        //Set it default to no spells color
        NoSpellStaff();
    }



    // Update is called once per frame
    void Update()
    {
        //If you have the fireball scroll
        if (fireballScroll)
        {
            FireballStaff();
        }
       //Fireball timer (counter so you can't spam)
        _fireballTime += Time.deltaTime;

    }

    //Function to turn top of staff to basic colors
    public void NoSpellStaff()
    {
        centerCrystalRenderer.sharedMaterial = noSpellMat[0];
        glowCrystalRenderer.sharedMaterial = noSpellMat[1];
    }
    //Function to turn the top of the staff to fire colors.
    public void FireballStaff()
    {
        centerCrystalRenderer.sharedMaterial = fireMat[0];
        glowCrystalRenderer.sharedMaterial = fireMat[1];
    }
    //Function to actually shoot fireball (gets called in controls on mouse 0)
    public void ShootFireBall()
    {
        //Make sure you have the fireball scroll, and that the timer is past how quickly you want to shoot
        if ( _fireballTime > fireballFireRate && fireballScroll)
        {
            //Make a fireball game object
            GameObject instFireball = Instantiate(fireball, transform.position, Quaternion.identity) as GameObject;
            //Get rigidbody of fireball
            Rigidbody instFireballRigid = instFireball.GetComponent<Rigidbody>();
            //Check where ray from middle of camera points 
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
            //Add force depending on speed and direction of ray
            instFireballRigid.AddForce(ray.direction * fireballSpeed);
            //reset fireball time
            _fireballTime = 0;
        }
    }
}
