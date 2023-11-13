using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private float velocity;
    [SerializeField] private Rigidbody rb;
    [SerializeField]
    private float maxLifeTime = 10f;
    private float lifeTimer = 0;

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

}
