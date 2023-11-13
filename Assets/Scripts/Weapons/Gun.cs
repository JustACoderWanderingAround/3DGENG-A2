using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public BulletConfigurationScriptableObject currBullet;

    float shootTimer, maxShootTimer, triggerHoldTimer;


    public override string GetClassName()
    {
        return "Gun";
    }
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
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            triggerHoldTimer += Time.deltaTime;
        }
        else
        {
            triggerHoldTimer = 0;
        }

    }
    public override bool Shoot()
    {
        if (shootTimer < 0 && currentBullets > 0)
        {
            currentBullets -= 1;
            shootTimer = maxShootTimer;
            GameObject newBullet = Instantiate(bulletPrefab, barrelTip.transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().Init(transform.parent.transform.forward, currBullet.BulletVelocity);
            return true;
        }
        else
            return false;

    }
    public override void Reload()
    {
       
        base.Reload();
        
    }
}
