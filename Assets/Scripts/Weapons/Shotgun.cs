using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    private int numShells = 3;
    [SerializeField]
    private Vector2 maxShellDisplacement = new Vector2(5, 3);
    private Vector2 maxShellDisplacementModifer = new Vector2(0.01f, 0.01f);

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
                transform.rotation.x + (Random.Range(-1 * maxShellDisplacement.x, maxShellDisplacement.x) * maxShellDisplacementModifer.x),
                transform.rotation.y + (Random.Range(-1 * maxShellDisplacement.y, maxShellDisplacement.y) * maxShellDisplacementModifer.y),
                0));
          
            GameObject newBullet = Instantiate(bulletPrefab, barrelTip.transform.position, newBulletQuat);
            newBullet.GetComponent<Bullet>().Init(transform.parent.transform.forward, currBullet.BulletVelocity);
        }
        currentBullets -= 1;
        shootTimer = maxShootTimer;
    }
}
