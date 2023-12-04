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
            Instantiate(deathEffect);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
            Debug.Log("Hit by projectile");
    }
    public void DealDamage (int damage)
    {
        health -= damage;
    }
}
