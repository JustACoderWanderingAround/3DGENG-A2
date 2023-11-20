using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunAimController : MonoBehaviour
{

    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private Vector3 currentPosition;
    private Vector3 targetPosition;

    private Vector3 hipPosition = new Vector3(0.5f, -0.16f, 0.34f);
    private Vector3 hipRotation = new Vector3(0, 0f, 0);

    private Vector3 aimPosition = new Vector3(0f, -0.125f, 0.35f);
    private Vector3 aimRotation = new Vector3(10f, 0f, 0f);

    public bool debugOnly;

    public Weapon mainWeapon;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (mainWeapon != null)
        {
            if (mainWeapon.aimPosVector != aimPosition)
            {
                aimPosition = mainWeapon.aimPosVector;
            }
            if (mainWeapon.aimRotVector != aimRotation)
            {
                aimRotation = mainWeapon.aimRotVector;
            }
            if (Input.GetAxisRaw("Fire2") > 0 || debugOnly)
            {
                targetPosition = aimPosition;
                targetRotation = aimRotation;
            }
            else
            {
                targetPosition = hipPosition;
                targetRotation = hipRotation;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (mainWeapon != null)
        {
            targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, mainWeapon.adsSpeed * Time.fixedDeltaTime);
            currentRotation = Vector3.Slerp(currentRotation, targetRotation, mainWeapon.adsSpeed * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(currentRotation);

            targetPosition = Vector3.Lerp(targetPosition, Vector3.zero, mainWeapon.adsSpeed * Time.fixedDeltaTime);
            currentPosition = Vector3.Slerp(currentPosition, targetPosition, mainWeapon.adsSpeed * Time.fixedDeltaTime);
            transform.localPosition = currentPosition;
        }
    }
}
