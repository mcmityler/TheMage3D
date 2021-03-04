using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBock : MonoBehaviour
{
    public Material[] deterMat;
    public GameObject deterObj;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = deterObj.GetComponent<Renderer>();
        //Make material default mat
        rend.sharedMaterial = deterMat[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Has a fireball hit a torch in scene 1
        if (collision.gameObject.tag == "Fireball")
        {
            if(rend.sharedMaterial == deterMat[0])
            {
                rend.sharedMaterial = deterMat[1];
            }
            else if (rend.sharedMaterial == deterMat[1])
            {
                rend.sharedMaterial = deterMat[2];
            }
            else if (rend.sharedMaterial == deterMat[2])
            {
                Destroy(gameObject);
            }
        }
    }
}
