using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotationController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation += mouseX;

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, mouseX, 0);
        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }
}
