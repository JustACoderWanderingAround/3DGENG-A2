using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class PlayerCrouchProneController : MonoBehaviour
{
    PlayerMovementController movementController;
    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
