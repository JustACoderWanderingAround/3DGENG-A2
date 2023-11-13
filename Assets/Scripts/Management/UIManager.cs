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
        // todo: update UI
        Debug.Log("UI Updated");
        ammoCounter.text = mainWeapon.currentBullets + " / " + ((mainWeapon.maxBullets * mainWeapon.magNum) + mainWeapon.leftoverBullets);
    }
}