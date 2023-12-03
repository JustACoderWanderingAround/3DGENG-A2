using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : IItem
{
    [SerializeField]
    protected GameObject bulletPrefab;

    public string gunName;

    public ShootConfigScriptableObject shootConfig;

    /// <summary>
    /// The transform where bullets spawn
    /// </summary>
    public GameObject barrelTip;
    

    /// <summary>
    /// maxBullets: number of bullets each mag can hold
    /// currentBullets: number of bullets in the current mag
    /// magNum: number of mags
    /// leftoverBullets: any bullets left over from reloads with mags not empty
    /// </summary>
    public int maxBullets;
    public int currentBullets;
    public int magNum;
    [HideInInspector]
    public int leftoverBullets = 0;

    public Vector3 recoil = new Vector3(1, 1, 1);

    public Vector3 adsRecoilModifier = new Vector3(0.8f, 0.8f, 0.8f);

    public float snappiness;
    public float returnSpeed;

    public float adsSpeed = 1f;

    public Vector3 aimPosVector = new Vector3(0f, -0.125f, 0.35f);
    public Vector3 aimRotVector = new Vector3(0f, -0.125f, 0.35f);


    public AudioClip gunshotAudio;

    public AudioClip reloadAudio;
    public abstract bool Shoot();

    public float aimZoomModifier = 1.0f;

    public virtual void Reload()
    {
        if (magNum >= 1)
        {
            magNum -= 1;
            leftoverBullets += currentBullets;
            currentBullets = maxBullets;
            if (leftoverBullets > 30)
            {
                magNum += 1;
                leftoverBullets -= 30;
            }
        }
        else if (leftoverBullets > 0)
        {
            currentBullets = leftoverBullets;
            leftoverBullets = 0;
        }
        // TODO: To be overriden with more functionalities
    }

}

