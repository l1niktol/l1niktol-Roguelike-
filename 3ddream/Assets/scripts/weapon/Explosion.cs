using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject exp1Prefab; // ссылка на префаб exp1
    public GameObject exp2Prefab; // ссылка на префаб exp2

    public float expLife = 3;

    private void Awake()
    {
        Destroy(gameObject, expLife);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy(collision.gameObject);
        GameObject exp1 = Instantiate(exp1Prefab) as GameObject;
        exp1.transform.position = transform.position;
        GameObject exp2 = Instantiate(exp2Prefab) as GameObject;
        exp2.transform.position = transform.position;
        Destroy(gameObject);

    }
}
