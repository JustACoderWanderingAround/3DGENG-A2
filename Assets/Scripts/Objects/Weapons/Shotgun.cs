using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    private int numShells = 3;
    [SerializeField]
    private Vector3 maxShellDisplacement = new Vector3(3, 3, 2);
    private Vector3 maxShellDisplacementModifer = new Vector3(0.05f, 0.05f, 0.05f);

    void Start()
    {
        currentBullets = maxBullets;
        shootTimer = 0;
        maxShootTimer = 60 / shootConfig.fireRate;
        canShoot = false;
        roundCounter = shootConfig.burstNum;
        xKeyDown = false;
    }
    public override string GetClassName()
    {
        return "Shotgun";
    }

    protected override void ShootBullet()
    {
        for (int i = 0; i < numShells; ++i)
        {
            Quaternion newBulletQuat = Quaternion.Euler(new Vector3(
                transform.parent.transform.forward.x + (Random.Range(-1 * maxShellDisplacement.x, maxShellDisplacement.x) * maxShellDisplacementModifer.x),
                transform.parent.transform.forward.y + (Random.Range(-1 * maxShellDisplacement.y, maxShellDisplacement.y) * maxShellDisplacementModifer.y),
                transform.parent.transform.forward.z + (Random.Range(-1 * maxShellDisplacement.z, maxShellDisplacement.z) * maxShellDisplacementModifer.z)));
            //Debug.Log("newbulletQuat: " + newBulletQuat.x + " " + newBulletQuat.y + " " + newBulletQuat.z);
            GameObject newBullet = Instantiate(bulletPrefab, barrelTip.transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().Init(newBulletQuat.eulerAngles, currBullet.BulletVelocity, shootConfig.damage);
        }
        currentBullets -= 1;
        shootTimer = maxShootTimer;
    }
}
