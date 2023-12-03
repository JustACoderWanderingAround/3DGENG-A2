using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimCameraZoomController : MonoBehaviour,IPlayerAimController
{

    private Camera zoomCamera;
    public bool isAiming;
    private Vector3 currentFOV = Vector3.zero, targetFOV = new Vector3(60, 0, 0);
    [SerializeField]
    private Vector3 defaultFOV = new Vector3(60, 0 ,0);

    Weapon mainWeapon;
    private void OnEnable()
    {
        zoomCamera = GetComponent<Camera>();    
    }
    // Update is called once per frame
    void Update()
    {
        if (mainWeapon != null)
            OnUpdate();
        if (isAiming)
        {
            OnAim();
        }
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
        targetFOV = new Vector3(mainWeapon.aimZoomModifier * defaultFOV.x, 0);
    }

    public void OnUpdate()
    {
        targetFOV = Vector3.Lerp(targetFOV, defaultFOV, mainWeapon.adsSpeed * Time.fixedDeltaTime);
        currentFOV = Vector3.Slerp(currentFOV, targetFOV, mainWeapon.adsSpeed * Time.fixedDeltaTime);
        zoomCamera.fieldOfView = currentFOV.x;
        targetFOV = defaultFOV;
    }
}
