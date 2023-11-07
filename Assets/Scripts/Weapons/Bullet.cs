using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private float velocity;
    [SerializeField] private Rigidbody rb;

    public void Init(Vector3 direction, float velocity)
    {
        this.direction = direction;
        this.velocity = velocity;
        rb.AddForce(direction.x * velocity, direction.y * velocity, direction.z * velocity, ForceMode.Impulse);
    }   
    
}
