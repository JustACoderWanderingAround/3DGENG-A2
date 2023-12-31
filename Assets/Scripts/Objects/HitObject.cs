using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private GameObject deathEffect;

    private void Update()
    {
        if (health < 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffect, 0.1f);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            DealDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
            

    }
    public void DealDamage (int damage)
    {
        health -= damage;
    }
}
