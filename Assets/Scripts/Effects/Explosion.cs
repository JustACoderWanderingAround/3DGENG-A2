using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Debug.Log(hit.gameObject.name);
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        GameObject instance = Instantiate(explosionEffect, transform.localPosition, transform.localRotation);
        Destroy(instance, 1.5f);
        Debug.Log("I exploded!");
    }
}
