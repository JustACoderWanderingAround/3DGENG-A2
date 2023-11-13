using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShootController : MonoBehaviour
{
    // Events invoked when player shoots
    private System.Action<Weapon, float> onShootEvents;
    public System.Action<Weapon, float> OnShootEvents
    {
        get { return onShootEvents;  }
    }

    public System.Action<Weapon> onReloadEvents;

    [SerializeField]
    private GameObject weaponSlot;

    [SerializeField]
    private GameObject recoilModifier;
    private PlayerGunRecoilRotator recoilRotator;

    /// TODO: use this implementation of mainWeapon once player can swap weapons
    //public Weapon MainWeapon
    //{
    //    get { return mainWeapon; }
    //    set { value = mainWeapon; }
    //}
    public Weapon mainWeapon;

    float triggerHoldTime = 0;

    private void OnEnable()
    {
        recoilRotator = recoilModifier.GetComponent<PlayerGunRecoilRotator>();
    }

    void Update()
    {
        if (recoilRotator.mainWeapon != mainWeapon)
        {
            recoilRotator.mainWeapon = mainWeapon;
        }
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (mainWeapon != null)
            {
                if (mainWeapon.Shoot())
                {
                    triggerHoldTime += Time.deltaTime;
                    onShootEvents.Invoke(mainWeapon, triggerHoldTime);
                    recoilRotator.RecoilFire();
                }
                
            }
        }
        else
        {
            triggerHoldTime = 0;
        }
        //todo: replace with axisRaw to allow flexible use of keys
        if (Input.GetKeyDown(KeyCode.R) && mainWeapon.currentBullets < mainWeapon.maxBullets)
        {
            Debug.Log("Before currB: " + mainWeapon.currentBullets + " leftOverB: " + mainWeapon.leftoverBullets + " magNum: " + mainWeapon.magNum);
            mainWeapon.Reload();
            onReloadEvents.Invoke(mainWeapon);
            Debug.Log("After currB: " + mainWeapon.currentBullets + " leftOverB: " + mainWeapon.leftoverBullets + " magNum: " + mainWeapon.magNum);
        }

    }
    public void SubscribeToShootEvent (System.Action<Weapon, float> onShootEvent)
    {
        onShootEvents += onShootEvent;
    }

    public void SubscribeToReloadEvent(System.Action<Weapon> onReloadEvent)
    {
        onReloadEvents += onReloadEvent;
    }
}
