using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
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

    public float recoilX;
    public float recoilY;
    public float recoilZ;

    public float snappiness;
    public float returnSpeed;


    public AudioClip gunshotAudio;

    public abstract string GetClassName();
    public abstract bool Shoot();
    
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

