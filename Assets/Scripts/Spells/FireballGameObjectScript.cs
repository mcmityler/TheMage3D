using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballGameObjectScript : MonoBehaviour
{
    public float destroyTime;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, destroyTime);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("TakeDamage", Damage);

        }
        Destroy(gameObject);
    }
}
