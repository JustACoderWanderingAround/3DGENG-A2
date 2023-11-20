using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Vector3 direction;
    protected float velocity;
    [SerializeField] 
    protected Rigidbody rb;
    [SerializeField]
    protected float maxLifeTime = 10f;
    protected float lifeTimer = 0;
    [SerializeField]
    protected GameObject collisionEffect;
    protected Collider col;

    public virtual void Init(Vector3 direction, float velocity)
    {
        this.direction = direction;
        this.velocity = velocity;
        rb.AddForce(direction.x * velocity, direction.y * velocity, direction.z * velocity, ForceMode.Impulse);
        col = GetComponent<Collider>();
        col.enabled = false;
    }
    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer > maxLifeTime)
        {
           Destroy(gameObject);
        }
        if (lifeTimer >= 0.01)
        {
            col.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject instance = Instantiate(collisionEffect, transform.localPosition, transform.localRotation);
        Destroy(instance, 1.5f);
        Destroy(gameObject);
    }

}
