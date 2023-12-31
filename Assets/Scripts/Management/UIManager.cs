using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour//, IShootObserver
{
    [SerializeField] private TMP_Text ammoCounter;
    public void UpdateUI(Weapon mainWeapon, float unused)
    {
        // todo: update UI
        Debug.Log("UI Updated");
        ammoCounter.text = mainWeapon.currentBullets + " / " + ((mainWeapon.maxBullets * mainWeapon.magNum) + mainWeapon.leftoverBullets)  ;
    }
    public void UpdateUI(Weapon mainWeapon)
    {
        if (mainWeapon == null)
        {
            ammoCounter.text = "No weapon!";
        }
        // todo: update UI
        //Debug.Log("UI Updated");
        else 
            ammoCounter.text = mainWeapon.currentBullets + " / " + ((mainWeapon.maxBullets * mainWeapon.magNum) + mainWeapon.leftoverBullets);
    }
    public void UpdateUI(IItem item)
    {
        if (item.GetClassName() == "Gun")
        {
            Weapon mainWeapon = (Weapon)item;
            Debug.Log("UI Updated");
            ammoCounter.text = mainWeapon.currentBullets + " / " + ((mainWeapon.maxBullets * mainWeapon.magNum) + mainWeapon.leftoverBullets);
        }
        else if (item.GetClassName() == "Grenade")
        {
            ammoCounter.text = "Press LMB to throw!";
        }
        
    }
}