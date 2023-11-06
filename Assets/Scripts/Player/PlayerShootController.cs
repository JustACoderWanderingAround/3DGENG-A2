using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShootController : MonoBehaviour
{
    // Events invoked when player shoots
    private System.Action<int, int, Vector3> onShootEvents;
    public System.Action<int, int, Vector3> OnShootEvents
    {
        get { return onShootEvents;  }
    }

    [SerializeField]
    private GameObject weaponSlot;

    public Weapon mainWeapon;

    //public Weapon MainWeapon
    //{
    //    get { return mainWeapon; }
    //    set { value = mainWeapon; }
    //}


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
                Debug.Log("mainWeaponNotNull");
                mainWeapon.Shoot();
                onShootEvents.Invoke(mainWeapon.CurrentBullets, mainWeapon.MaxBullets, mainWeapon.BarrelTip);
            }
        }

    }
    public void Subscribe (System.Action<int, int, Vector3> onShootEvent)
    {
        onShootEvents += onShootEvent;
    }
}
