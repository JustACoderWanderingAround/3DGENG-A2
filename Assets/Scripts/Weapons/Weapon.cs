using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject bulletPrefab;

    //public List<Bullet> ammoTypes;

    public string gunName;

    public ShootConfigScriptableObject shootConfig;


    protected Vector3 barrelTip;
    public Vector3 BarrelTip
    {
        get { return barrelTip; }
    }

    public int maxBullets;
    public int currentBullets;
    public int magNum;
    //public int MaxBullets   // property
    //{
    //    get { return maxBullets; }   // get method
    //    set { maxBullets = value; }  // set method
    //}

    //public int CurrentBullets   // property
    //{
    //    get { return currentBullets; }   // get method
    //    set { currentBullets = value; }  // set method
    //}

    public abstract bool Shoot();
    
    public virtual void Reload()
    {
        currentBullets = maxBullets;
        // TODO: To be overriden with more functionalities
    }
}

