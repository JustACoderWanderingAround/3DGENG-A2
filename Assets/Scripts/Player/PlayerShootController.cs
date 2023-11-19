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

    public System.Action<Weapon> onSwapEvents;

    [SerializeField]
    private GameObject weaponSlot;

    [SerializeField]
    private GameObject recoilModifier;
    private PlayerGunRecoilRotator recoilRotator;
    [SerializeField]
    private PlayerGunAimController aimController;

    /// TODO: use this implementation of mainWeapon once player can swap weapons
    //public Weapon MainWeapon
    //{
    //    get { return mainWeapon; }
    //    set { value = mainWeapon; }
    //}
    /*public*/ Weapon mainWeapon;

    float triggerHoldTime = 0;

    private int activeGunIndex = 0;

    private void OnEnable()
    {
        recoilRotator = recoilModifier.GetComponent<PlayerGunRecoilRotator>();
        mainWeapon = weaponSlot.transform.GetChild(0).GetComponent<Weapon>();
        weaponSlot.transform.GetChild(0).gameObject.SetActive(true);
    }

    void Update()
    {
        if (recoilRotator.mainWeapon != mainWeapon)
        {
            recoilRotator.mainWeapon = mainWeapon;
        }
        if (aimController.mainWeapon != mainWeapon)
        {
            aimController.mainWeapon = mainWeapon;
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
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        } 
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SwapWeapon(2);
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

    public void SubscribeToWeaponSwapEvent(System.Action<Weapon> onSwapEvent)
    {
        onSwapEvents += onSwapEvent;
    }
    public void SwapWeapon(int index)
    {
        weaponSlot.transform.GetChild(activeGunIndex).gameObject.SetActive(false);
        activeGunIndex = index;
        weaponSlot.transform.GetChild(activeGunIndex).gameObject.SetActive(true);
        mainWeapon = weaponSlot.transform.GetChild(activeGunIndex).GetComponent<Weapon>();

    }
}
