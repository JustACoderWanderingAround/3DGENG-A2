using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedLauncher : Gun
{
    bool isLocked;
    RaycastHit raycastHit;
    private GameObject objectToTrack;
    public override string GetClassName()
    {
        return "GuidedLauncher";
    }
    // Start is called before the first frame update
    void Start()
    {
        isLocked = false;   
    }

    // Update is called once per frame
    void Update()
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
    }

    public override bool Shoot()
    {
        if (isLocked == false)
        {
            bool targetLocked = LockTarget();
            if (targetLocked)
            {
                isLocked = true;
                
            }
        }
        else
        {
            currentBullets -= 1;
            shootTimer = maxShootTimer;
            GameObject newBullet = Instantiate(bulletPrefab, barrelTip.transform.position, transform.rotation);
            newBullet.GetComponent<TargetTrack>().InitTrack(objectToTrack);
            newBullet.GetComponent<Bullet>().Init(transform.parent.transform.forward, currBullet.BulletVelocity, shootConfig.damage);
            return true;
        }
        return false;
    }
    bool LockTarget()
    {
        Ray lockingRay = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(lockingRay, out hit))
        {
            Debug.Log("casted");
            HitObject hitObject = hit.collider.gameObject.GetComponent<HitObject>();
            Debug.Log("hasHitObj" + hitObject != null);
            if (hitObject != null)
            {
                objectToTrack = hitObject.gameObject;
                return true;
            }
        }
        return false;
    }
}
