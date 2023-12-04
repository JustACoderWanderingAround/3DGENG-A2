using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rocket))]
public class TargetTrack : MonoBehaviour
{
    private GameObject target;

    [SerializeField]
    private float rotationSpeed = 10f;
    public void InitTrack(GameObject objectToTrack)
    {
        target = objectToTrack;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction from the current position to the target position
        Vector3 directionToTarget = target.transform.position - transform.position;

        // Calculate the rotation to look at the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Gradually rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
