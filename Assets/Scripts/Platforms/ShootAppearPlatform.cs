using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAppearPlatform : MonoBehaviour
{
    Renderer rend;
    Color color;

    public Material[] shootMat;
    public float fadeSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = shootMat[0];
        color = shootMat[1].color;
    }

    // Update is called once per frame
    void Update()
    {
        if(rend.sharedMaterial == shootMat[0])
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
        if(color.a > 0.5f)
        {
            color.a -= Time.deltaTime * fadeSpeed;
            this.GetComponent<MeshRenderer>().material.color = color;
        }else
        {
            rend.sharedMaterial = shootMat[0];
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }


    public void OnTriggerStay(Collider col)
    {
        //When hit with fireball start a timer and until platform disappears again, maybe changes alpha back
        if (col.gameObject.tag == "Fireball")
        {
            color.a = 1;
            rend.sharedMaterial = shootMat[1];

            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
