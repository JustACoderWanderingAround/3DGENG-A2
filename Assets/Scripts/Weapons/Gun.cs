using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public new GameObject barrelTip;
    public BulletConfigurationScriptableObject currBullet;

    float shootTimer, maxShootTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
        shootTimer = 0;
        maxShootTimer = 60 / shootConfig.fireRate;

    }
    private void Update()
    {
        if (shootTimer > -1)
            shootTimer -= Time.deltaTime;
    }
    public override bool Shoot()
    {
        if (shootTimer < 0)
        {
            shootTimer = maxShootTimer;
            GameObject newBullet = Instantiate(bulletPrefab, barrelTip.transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().Init(transform.parent.transform.forward, currBullet.BulletVelocity);
            return true;
        }
        else
            return false;

    }
}
