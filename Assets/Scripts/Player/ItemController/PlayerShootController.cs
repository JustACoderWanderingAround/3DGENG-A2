using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShootController : IItemTypeController
{
    // Events invoked when player shoots
    private System.Action<Weapon> onShootEvents;
    public System.Action<Weapon> OnShootEvents
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
    [SerializeField]
    private PlayerAimCameraZoomController zoomController;

    private List<IPlayerAimController> playerAimControllers;
    /// TODO: use this implementation of mainWeapon once player can swap weapons
    //public Weapon MainWeapon
    //{
    //    get { return mainWeapon; }
    //    set { value = mainWeapon; }
    //}
    /*public*/
    Weapon mainWeapon;

    float triggerHoldTime = 0;

    private int activeGunIndex = 0;

    public void SetMainWeapon(Weapon newWeapon)
    {
        mainWeapon = newWeapon;
    }

    private void Awake()
    {
        // set the game object which modifies camera recoil
        recoilRotator = recoilModifier.GetComponent<PlayerGunRecoilRotator>();
        playerAimControllers = new List<IPlayerAimController> { aimController, zoomController, recoilRotator };
    }
    private void OnEnable()
    {
       
    }

    void Update()
    {
        // check aim classes
        if (recoilRotator.GetMainWeapon() != mainWeapon)
        {
            recoilRotator.SetMainWeapon(mainWeapon);
        }
        if (aimController.GetMainWeapon() != mainWeapon)
        {
            aimController.SetMainWeapon(mainWeapon);
            onReloadEvents.Invoke(mainWeapon);
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

    public override void UseLeftMouseButton()
    {
        if (mainWeapon != null)
        {
            bool mainWeaponShoot = mainWeapon.Shoot();
            if (mainWeaponShoot)
            {

                triggerHoldTime += Time.deltaTime;
                onShootEvents.Invoke(mainWeapon);
                recoilRotator.RecoilFire();
            }

        }
        else
            onSwapEvents.Invoke(null);
    }

    public override void UseRightMouseButton()
    {
        //zoomController.AimCamera(mainWeapon);
        for (int i = 0; i < playerAimControllers.Count; ++i)
        {
            playerAimControllers[i].OnAim();
        }
    }

    public override void SetMainItem(IItem newMainItem)
    {
        mainWeapon = (Weapon)newMainItem;
        for (int i = 0; i < playerAimControllers.Count; ++i)
        {
            playerAimControllers[i].SetMainWeapon(mainWeapon);
        }
    }

    public void SubscribeToShootEvent (System.Action<Weapon> onShootEvent)
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

    public override IItem GetMainItem()
    {
        return mainWeapon;
    }
}
