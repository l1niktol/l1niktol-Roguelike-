using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3;
    public float damage = 1f;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
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
