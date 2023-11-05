using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField]
    private float moveSpeed = 5.0f;

    [Header("Ground Check")]
    public LayerMask groundLayer;

    [SerializeField]
    private float playerHeight = 0.5f;
   

    [SerializeField]
    private float playerGroundDrag  = 10f;
    
    

    bool grounded;

    [SerializeField]
    private Transform orientation;

    private Rigidbody rb;

    float horizontalInput;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (grounded)
            rb.drag = playerGroundDrag;
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        // calculate player direction
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
    }
}
