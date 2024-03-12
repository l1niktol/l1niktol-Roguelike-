using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3;

    [SerializeField]
    private float minRange = 0f;

    [SerializeField]
    private float maxRange = 1f;

    private float damage;
    

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }
    public void Start()
    {
        damage = Mathf.FloorToInt(Random.Range(minRange, maxRange));
    }

    private void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject, bulletLife);

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

    }
}
