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
    private Vector3 aimPosition = new Vector3(0f, -0.16f, 0.34f);

    private Vector3 hipRotation = new Vector3(0, 5.66f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire2") > 0)
        {
            //transform.localPosition = aimPosition;
            //transform.localRotation = Quaternion.identity;
            targetPosition = aimPosition;
            targetRotation = hipRotation;

        }
        else
        {
            //transform.localPosition = hipPosition;
            //Quaternion newQuat = Quaternion.Euler(0, hipRotation.y, 0);
            //transform.localRotation = newQuat;
            targetPosition = hipPosition;
            targetRotation = new Vector3(0, 0, 0);
            //Quaternion newQuat = Quaternion.Euler(0, hipRotation.y, 0);
            //targetRotation = newQuat;
        }
        //transform.localPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime);
        //transform.localRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime);

        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
        targetPosition = Vector3.Lerp(targetPosition, Vector3.zero,  Time.deltaTime);
        currentPosition = Vector3.Slerp(currentPosition, targetPosition, Time.fixedDeltaTime);
        transform.localPosition = currentPosition;
    }
}
