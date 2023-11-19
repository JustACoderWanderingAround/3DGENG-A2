using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Vector3 direction;
    protected float velocity;
    [SerializeField] protected Rigidbody rb;
    [SerializeField]
    protected float maxLifeTime = 10f;
    protected float lifeTimer = 0;
    [SerializeField]
    protected GameObject collisionEffect;

    public void Init(Vector3 direction, float velocity)
    {
        this.direction = direction;
        this.velocity = velocity;
        rb.AddForce(direction.x * velocity, direction.y * velocity, direction.z * velocity, ForceMode.Impulse);
    }
    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer > maxLifeTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject instance = Instantiate(collisionEffect, transform.localPosition, transform.localRotation);
        Destroy(instance, 1.5f);
        Destroy(this);
    }

}
