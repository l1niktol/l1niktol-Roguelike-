using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    public float bulletLife = 3;

    

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }
    //public GameObject exp1Prefab; // ������ �� ������ exp1
    //public GameObject exp2Prefab; // ������ �� ������ exp2

   

    private void OnCollisionEnter(Collision collision)
    {


         //Destroy(collision.gameObject);
       
            //GameObject exp1 = Instantiate(exp1Prefab) as GameObject;
            //exp1.transform.position = transform.position;
            //GameObject exp2 = Instantiate(exp2Prefab) as GameObject;
            //exp2.transform.position = transform.position;
            Destroy(gameObject, bulletLife);
        
    }
}
