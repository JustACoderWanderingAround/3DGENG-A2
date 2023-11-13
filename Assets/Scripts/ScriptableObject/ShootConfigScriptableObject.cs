using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Shoot Config", menuName = "Guns/Shoot Config", order = 2)]
public class ShootConfigScriptableObject : ScriptableObject
{
    // Changes behaviour based on whether gun is hitscan or not
    public bool isHitscan = true;
    // Fire rate of the gun
    public float fireRate;

    public float maxSpreadTime;

    public Vector3 barrelTip;
    ///
    /// This enum determines how the recoil reacts - will it go straight up? straight down?
    /// left and right? 
    /// up then down? right then left?
    ///
    public enum BehaviourType
    {
        LINEAR,
        SINE,
        QUADRATIC
    }

    public BehaviourType horiRecoilBehaviour;
    public BehaviourType vertRecoilBehaviour;

    // Max offset from forward when firing
    public Vector2 maxRecoilOffset;
    public Vector3 cameraShakeStrength;

    /// <summary>
    /// All offsets from the forward direction are a function of time.
    /// This function calculates the offset on each axis based on a specific formulae.
    /// </summary>
    /// <param name="shootTime">The amount of time the player has held the trigger.</param>
    public Vector3 GenerateSpreadAtPoint(float shootTime)
    {
        Vector3 spread = Vector3.zero;

        /// psuedocode:
        /// for each axis:
        ///     if behaviourType is linear
        ///         lerp from 0 to maxRecoilOffset.axis
        ///     else if behaviourType is sine
        ///         lerp from 0 to maxRecoilOffset.axis
        ///         apply sine equation to result
        ///     else if behaviourType is quadratic
        ///         apply quadratic equation to result
        ///         -> SLERP         
        switch (horiRecoilBehaviour) {
            case BehaviourType.LINEAR:
                spread.x = (Vector3.Lerp(Vector3.zero, cameraShakeStrength, Mathf.Clamp(shootTime / maxSpreadTime, 0f, 1f))).x;
                break;
            case BehaviourType.SINE:
                spread.x = Mathf.Sin(shootTime * cameraShakeStrength.x);
                break;
            case BehaviourType.QUADRATIC:
                spread.x = (Vector3.Slerp(Vector2.zero, cameraShakeStrength, Mathf.Clamp(shootTime / maxSpreadTime, 0f, 1f))).x;
                break;
        }
        switch (vertRecoilBehaviour)
        {
            case BehaviourType.LINEAR:
                spread.y = (Vector3.Lerp(Vector3.zero, cameraShakeStrength, Mathf.Clamp(shootTime / maxSpreadTime, 0f, 1f))).y;
                break;
            case BehaviourType.SINE:
                spread.y = Mathf.Sin(shootTime * cameraShakeStrength.y);
                break;
            case BehaviourType.QUADRATIC:
                spread.y = (Vector3.Slerp(Vector2.zero, cameraShakeStrength, Mathf.Clamp(shootTime / maxSpreadTime, 0f, 1f))).y;
                break;
        }

        return spread;
    }
}