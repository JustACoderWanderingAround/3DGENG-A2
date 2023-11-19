using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Shoot Config", menuName = "Weapons/Shoot Config", order = 2)]
public class ShootConfigScriptableObject : ScriptableObject
{
    // Changes behaviour based on whether gun is hitscan or not
    public bool isHitscan = true;
    // Fire rate of the gun
    public float fireRate;
    // Number of rounds in a burst
    public int burstNum;

    public float maxSpreadTime;

    public Vector2 maxRecoilOffset;

    public Vector3 cameraShakeStrength;

    public int damage;

    public bool canAuto;

    public bool canBurst;
}