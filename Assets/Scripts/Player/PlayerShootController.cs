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
        // set the game object which modifies camera recoil

        recoilRotator = recoilModifier.GetComponent<PlayerGunRecoilRotator>();
        if (weaponSlot.transform.childCount > 0)
        {
            for (int i = 0; i < weaponSlot.transform.childCount; ++i)
            {
                weaponSlot.transform.GetChild(i).gameObject.SetActive(false);
            }
            mainWeapon = weaponSlot.transform.GetChild(0).GetComponent<Weapon>();
            weaponSlot.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        // check aim classes
        if (recoilRotator.mainWeapon != mainWeapon)
        {
            recoilRotator.mainWeapon = mainWeapon;
        }
        if (aimController.mainWeapon != mainWeapon)
        {
            aimController.mainWeapon = mainWeapon;
            onReloadEvents.Invoke(mainWeapon);
        }
        // on set aim toggling
        
        recoilRotator.SetIsAiming(Input.GetAxisRaw("Fire2") > 0);
        aimController.SetIsAiming(Input.GetAxisRaw("Fire2") > 0);

        // on fire events
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (mainWeapon != null)
            {
                bool mainWeaponShoot = mainWeapon.Shoot();
                Debug.Log(mainWeaponShoot);
                if (mainWeaponShoot)
                {

                    triggerHoldTime += Time.deltaTime;
                    onShootEvents.Invoke(mainWeapon, triggerHoldTime);
                    recoilRotator.RecoilFire();
                }

            }
            else
                onSwapEvents.Invoke(null);
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
        int numberOfWeapons = 4; // Change this to the number of weapons you have
        for (int i = 1; i <= numberOfWeapons; i++)
        {
            if (Input.GetKey(KeyCode.Alpha0 + i))
            {
                SwapWeapon(i - 1);
                break; // Stop checking for keys once one is pressed
            }
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
        if (weaponSlot.transform.GetChild(index) != null)
        {
            if (weaponSlot.transform.childCount > 1)
            {
                for (int i = 0; i < weaponSlot.transform.childCount; ++i)
                {
                    weaponSlot.transform.GetChild(i).gameObject.SetActive(false);
                }
                
            }
            mainWeapon = weaponSlot.transform.GetChild(index).GetComponent<Weapon>();
            weaponSlot.transform.GetChild(index).gameObject.SetActive(true);
        }
        else return;

    }
}
