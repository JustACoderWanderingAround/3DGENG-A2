using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class handles any funky shit related to the camera.
/// This includes localTransform and anything that changes it (like camera shake)
/// </summary>
public class CameraManager : MonoBehaviour
{
    float deltaTime = 0;
    Vector3 startPosition;
    public float duration;
    private Vector3 newPosition;
    private void OnEnable()
    {
        Vector3 startPosition = transform.localPosition;
    }
    private void Update()
    {
        deltaTime += Time.deltaTime;
    }
    // Gun recoil (actually affects aim)

    // Camera shake VFX
    public void OneShake(Weapon mainWeapon)
    {
        StartCoroutine(PerformComplexShake(0.1f, mainWeapon));
        transform.localRotation = Quaternion.identity;
    }
    public void OneShake()
    {
      
    }
    IEnumerator PerformComplexShake(float duration, Weapon mainWeapon)
    {
        Quaternion startRotation = transform.localRotation;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            transform.localRotation = Quaternion.Euler(new Vector3(
                Random.Range(-mainWeapon.shootConfig.cameraShakeStrength.x, mainWeapon.shootConfig.cameraShakeStrength.x),
                Random.Range(-mainWeapon.shootConfig.cameraShakeStrength.y, mainWeapon.shootConfig.cameraShakeStrength.y),
                Random.Range(-mainWeapon.shootConfig.cameraShakeStrength.z, mainWeapon.shootConfig.cameraShakeStrength.z)
                
            )); ;
            Vector3 currPos = this.transform.position;
            //newPosition = new Vector3(currPos.x + Random.Range(-0.05f, 0.05f), currPos.y + Random.Range(-0.1f, 0.05f), startPosition.z);

            //transform.position = newPosition;


            yield return null;
        }

        transform.localRotation = startRotation;
        //transform.localPosition = startPosition;
    }
}
