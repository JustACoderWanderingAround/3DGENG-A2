using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimCameraZoomController : MonoBehaviour
{

    private Camera camera;
    public bool isAiming;
    private void OnEnable()
    {
        camera = GetComponent<Camera>();    
    }
    // Update is called once per frame
    void Update()
    {
        camera.fieldOfView = 60;
    }
    public void AimCamera(Weapon mainWeapon)
    {
        // todo:
        // lerp lerp lerp
        float newFOV = 60 * mainWeapon.aimZoomModifier;
        camera.fieldOfView = newFOV;
    }
}
