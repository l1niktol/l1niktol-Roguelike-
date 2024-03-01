using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydayn : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1.0f;
    public float health = 100;
    public float damage = 20;


   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
    
}
