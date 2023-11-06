using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Vector3 barrelTip;
    public BulletConfigurationScriptableObject currBullet;
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
    }
    public override void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, gameObject.transform.position + barrelTip, Quaternion.identity);
        newBullet.GetComponent<Bullet>().Init(transform.forward, currBullet.BulletVelocity);

    }
}
