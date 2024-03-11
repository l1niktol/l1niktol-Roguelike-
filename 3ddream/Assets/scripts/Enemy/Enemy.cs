using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1.0f;
    public float health = 100f;


    public GameObject expPrefab; //префаб дыма
    public GameObject SpawnDestroy; //спавн
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject exp1 = Instantiate(expPrefab) as GameObject;
            exp1.transform.position = SpawnDestroy.transform.position;
        }
    }


}
