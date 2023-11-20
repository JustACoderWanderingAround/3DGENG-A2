using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    public float thrust = 5f;
    public float thrustTime = 2f;
    float thrustTimer;
    // Start is called before the first frame update
    void Start()
    {
        thrustTimer = 0;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        col.enabled = false;
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
        if (rb)
            if (thrustTimer < thrustTime)
            {
                rb.AddForce(thrust * gameObject.transform.forward, ForceMode.Impulse);
                Debug.Log("Thrust");
            }

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject instance = Instantiate(collisionEffect, transform.localPosition, transform.localRotation);
        Destroy(instance, 1.5f);

        Destroy(this);
    }
}
