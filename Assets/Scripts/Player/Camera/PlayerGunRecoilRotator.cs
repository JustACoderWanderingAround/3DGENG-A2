using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRecoilRotator : MonoBehaviour
{

    private Vector3 currentRotation;
    private Vector3 targetRotation;

    //public float recoilX;
    //public float recoilY;
    //public float recoilZ;

    //public float snappiness;
    //public float returnSpeed;
    public Weapon mainWeapon;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, mainWeapon.returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, mainWeapon.snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
    
    public void RecoilFire()
    {
        targetRotation += new Vector3(mainWeapon.recoilX, Random.Range(-mainWeapon.recoilY, mainWeapon.recoilY), Random.Range(-mainWeapon.recoilZ, mainWeapon.recoilZ));
    }
}
