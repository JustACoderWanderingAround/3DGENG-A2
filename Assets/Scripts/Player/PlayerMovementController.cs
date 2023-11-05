using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player movement controller class. controls X, Y, and Z movement actions of the player.
/// Adopted from https://www.youtube.com/watch?v=f473C43s8nE
/// </summary>
public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float runningMulti = 1.25f;

    [Header("Ground Check")]
    public LayerMask groundLayer;

    [SerializeField]
    private float playerHeight = 0.5f;
   

    [SerializeField]
    private float playerGroundDrag  = 10f;
    
    bool grounded;
    bool canJump;

    [SerializeField]
    private Transform orientation;

    private Rigidbody rb;

    float horizontalInput;
    float verticalInput;
    bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isRunning = (Input.GetAxisRaw("Fire3") > 0);
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
        Vector3 moveDirection = new Vector3(orientation.forward.x, 0, orientation.forward.z).normalized * verticalInput + new Vector3(orientation.right.x, 0, orientation.right.z).normalized * horizontalInput;
        if (isRunning)
            rb.AddForce(moveDirection.normalized * (runningMulti * moveSpeed) * 10f, ForceMode.Force);
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        Debug.Log("IsRuning: " + isRunning);
    }

    private void Jump()
    {

        // reset Y velocity just in case
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);

        rb.AddForce(transform.up, ForceMode.Force);
    }
    private void ResetJump()
    {

    }
}
