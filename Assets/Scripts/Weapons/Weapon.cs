using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public List<Bullet> ammoTypes;

    public string name;

    public ShootConfigScriptableObject shootConfig;

    private int maxBullets;
    private int currentBullets;

    public int MaxBullets   // property
    {
        get { return maxBullets; }   // get method
        set { maxBullets = value; }  // set method
    }

    public int CurrentBullets   // property
    {
        get { return currentBullets; }   // get method
        set { currentBullets = value; }  // set method
    }

    public abstract void Shoot();
    
    public virtual void Reload()
    {
        currentBullets = maxBullets;
        // TODO: To be overriden with more functionalities
    }
}

