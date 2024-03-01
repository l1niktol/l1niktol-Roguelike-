using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydayn : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1.0f;
    public float health = 100f;
    public float damage = 20f;
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Bullet")
        {
            health -= damage;
        }
    }
}
