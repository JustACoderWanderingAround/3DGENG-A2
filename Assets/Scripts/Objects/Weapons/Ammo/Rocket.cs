using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Rocket : Bullet
{
    public float thrust = 5f;
    public float thrustTime = 2f;
    float thrustTimer;
    private Explosion explosion;
    // Start is called before the first frame update
    void Start()
    {
        thrustTimer = 0;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        col.enabled = false;
        explosion = GetComponent<Explosion>();
    }
    public override void Init(Vector3 direction, float velocity)
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (thrustTimer > 0.05f)
            col.enabled = true;
        thrustTimer += Time.deltaTime;
        lifeTimer += Time.deltaTime;
        if (lifeTimer > maxLifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (thrustTimer < thrustTime)
        {
            rb.AddForce(thrust * gameObject.transform.forward, ForceMode.Impulse);
            thrust -= Time.deltaTime;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Rocket coll with " + collision.gameObject.name);
        GameObject instance = Instantiate(collisionEffect, transform.localPosition, transform.localRotation);
        Destroy(instance, 1.5f);
        explosion.Explode();
        Destroy(gameObject);
    }
}
