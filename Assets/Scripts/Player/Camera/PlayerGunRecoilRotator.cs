using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRecoilRotator : MonoBehaviour, IPlayerAimController
{

    private Vector3 currentRotation;
    private Vector3 targetRotation;

    //public float recoilX;
    //public float recoilY;
    //public float recoilZ;

    //public float snappiness;
    //public float returnSpeed;
    public Weapon mainWeapon;
    bool isAiming;

    private void OnEnable()
    {
        isAiming = false;
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (mainWeapon != null)
        {
            targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, mainWeapon.returnSpeed * Time.fixedDeltaTime);
            currentRotation = Vector3.Slerp(currentRotation, targetRotation, mainWeapon.snappiness * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }
    }
    public void RecoilFire()
    {
   
        if (isAiming)
        {
            Debug.Log("recoilfire aim bang bang");
            targetRotation += new Vector3(-mainWeapon.recoil.x * mainWeapon.adsRecoilModifier.x, Random.Range(-mainWeapon.recoil.y, mainWeapon.recoil.y) * mainWeapon.adsRecoilModifier.y, Random.Range(-mainWeapon.recoil.z, mainWeapon.recoil.z) * mainWeapon.adsRecoilModifier.z);
        }
        else
        {
            Debug.Log("recoilfire bang bang");
            targetRotation += new Vector3(-mainWeapon.recoil.x, Random.Range(-mainWeapon.recoil.y, mainWeapon.recoil.y), Random.Range(-mainWeapon.recoil.z, mainWeapon.recoil.z));
        }
    }
    public void SetIsAiming(bool isAiming)
    {
        if (this.isAiming != isAiming)
            this.isAiming = isAiming;
    }

    public void SetMainWeapon(Weapon mainWeapon)
    {
        this.mainWeapon = mainWeapon;
    }

    public Weapon GetMainWeapon()
    {
        return mainWeapon;
    }

    public void OnAim()
    {
        isAiming = true;
    }

    public void OnUpdate()
    {
        if (mainWeapon != null)
        {
            targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, mainWeapon.returnSpeed * Time.fixedDeltaTime);
            currentRotation = Vector3.Slerp(currentRotation, targetRotation, mainWeapon.snappiness * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }
    }
}
