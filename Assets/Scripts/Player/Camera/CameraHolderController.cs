using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolderController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPosition;
    [SerializeField]
    private Transform cameraRotation;
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraRotation.rotation;
    }
}
