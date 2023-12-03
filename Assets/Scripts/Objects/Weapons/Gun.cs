using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public enum FireMode
    {
        MODE_SEMIAUTO = 0,
        MODE_AUTO = 1,
        MODE_BURST = 2,
        NUM_MODES
    }
    public FireMode fireMode = FireMode.MODE_SEMIAUTO;
    public BulletConfigurationScriptableObject currBullet;

    protected float shootTimer, maxShootTimer, triggerHoldTimer;

    protected bool canShoot;

    protected int roundCounter;
    protected bool xKeyDown;
    public override string GetClassName()
    {
        return "Gun";
    }
    // Start is called before the first frame update
    void Awake()
    {
        currentBullets = maxBullets;
        shootTimer = 0;
        maxShootTimer = 60 / shootConfig.fireRate;
        canShoot = false;
        roundCounter = shootConfig.burstNum;
        xKeyDown = false;
    }
    private void Update()
    {
        if (shootTimer > -1)
            shootTimer -= Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") < 1)
        {
            canShoot = true;
            if (roundCounter < shootConfig.burstNum)
            {
                roundCounter = shootConfig.burstNum;
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && xKeyDown == false)
        {
            xKeyDown = true;
            Debug.Log("swapped");
            SwapFireMode();
        }
        else
        {
           xKeyDown = false;
        }
    }
    public override bool Shoot()
    {
        if (shootTimer < 0 && currentBullets > 0 && canShoot)
        {
            switch (fireMode)
            {
                case FireMode.MODE_SEMIAUTO:
                    ShootBullet();
                    canShoot = false;
                    return true;
                case FireMode.MODE_AUTO:
                    ShootBullet();
                    return true;
                case FireMode.MODE_BURST:
                    if (roundCounter > 0)
                    {
                        ShootBullet();
                        roundCounter -= 1;
                        if (roundCounter < 1)
                        {
                            canShoot = false;
                        }
                        return true;
                    }
                    else
                        return false;
                default:
                    return false;
            }
        }
        else
            return false;
    }
    public override void Reload()
    {

        base.Reload();

    }
    protected virtual void ShootBullet()
    {
        currentBullets -= 1;
        shootTimer = maxShootTimer;
        GameObject newBullet = Instantiate(bulletPrefab, barrelTip.transform.position, transform.rotation);
        newBullet.GetComponent<Bullet>().Init(transform.parent.transform.forward, currBullet.BulletVelocity);
    }
    //private void SwapFireMode() 
    //{
    //    if (fireMode == FireMode.MODE_SEMIAUTO)
    //    {
    //        if (shootConfig.canAuto)
    //        {
    //            fireMode = FireMode.MODE_AUTO;
    //        }
    //        else if (shootConfig.canBurst)
    //        {
    //            fireMode = FireMode.MODE_BURST;
    //        }
    //    }
    //    else if (fireMode == FireMode.MODE_AUTO)
    //    {
    //        if (shootConfig.canBurst)
    //        {
    //            fireMode = FireMode.MODE_BURST;
    //        }
    //        else
    //        {
    //            fireMode = FireMode.MODE_SEMIAUTO;
    //        }
    //    }
    //    else if (fireMode == FireMode.MODE_BURST)
    //    {
    //        fireMode = FireMode.MODE_SEMIAUTO;
    //    }
    //}
    private void SwapFireMode()
    {
        if (!shootConfig.canBurst && !shootConfig.canAuto)
        {
            return;
        }
        switch (fireMode)
        {
            case FireMode.MODE_SEMIAUTO:
                if (shootConfig.canAuto)
                {
                    fireMode = FireMode.MODE_AUTO;
                    Debug.Log("auto");
                }
                else if (shootConfig.canBurst)
                {
                    fireMode = FireMode.MODE_BURST;
                    Debug.Log("burst");
                }
                break;

            case FireMode.MODE_AUTO:
                fireMode = shootConfig.canBurst ? FireMode.MODE_BURST : FireMode.MODE_SEMIAUTO;
                break;

            case FireMode.MODE_BURST:
                fireMode = FireMode.MODE_SEMIAUTO;
                Debug.Log("auto");
                break;
        }
    }
}
