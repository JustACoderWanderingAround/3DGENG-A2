using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Grenade : Throwable
{
    Explosion explosion;

    [SerializeField]
    private float grenadeTimer = 5.0f;

    private bool startTimer = false;
    public override void Use()
    {
        startTimer = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<Explosion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            grenadeTimer -= Time.deltaTime;
        }
        if (grenadeTimer <= 0)
        {
            explosion.Explode();
        }
    }
}
