using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShootController : MonoBehaviour
{
    // Events invoked when player shoots
    private System.Action<Weapon> onShootEvents;
    public System.Action<Weapon> OnShootEvents
    {
        get { return onShootEvents;  }
    }

    public System.Action<Weapon> onReloadEvents;

    [SerializeField]
    private GameObject weaponSlot;



    [SerializeField]
    private GameObject orientation;

    /// TODO: use this implementation of mainWeapon once player can swap weapons
    //public Weapon MainWeapon
    //{
    //    get { return mainWeapon; }
    //    set { value = mainWeapon; }
    //}
    public Weapon mainWeapon;

    void Update()
    {
        //if (weaponSlot.transform.GetChild(0).gameObject.GetComponent<Weapon>())
        //{
        //    mainWeapon = weaponSlot.transform.GetChild(0).gameObject.GetComponent<Weapon>();
        //}
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (mainWeapon != null)
            {
                if (mainWeapon.Shoot())
                {
                    onShootEvents.Invoke(mainWeapon);
                }
                
            }
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
    public void SubscribeToShootEvent (System.Action<Weapon> onShootEvent)
    {
        onShootEvents += onShootEvent;
    }

    public void SubscribeToReloadEvent(System.Action<Weapon> onReloadEvent)
    {
        onReloadEvents += onReloadEvent;
    }
}
