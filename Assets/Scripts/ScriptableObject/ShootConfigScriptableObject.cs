using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Shoot Config", menuName = "Guns/Shoot Config", order = 2)]
public class ShootConfigScriptableObject : ScriptableObject
{
    // Changes behaviour based on whether gun is hitscan or not
    public bool isHitscan = true;
    // Prefab that will be shot out of the front of the gun
    public Bullet bulletPrefab;
    // Fire rate of the gun
    public float fireRate;
  
    // Determines how recoil behaves
    public RecoilBehaviour recoilBehaviour;


    public float maxSpreadTime;

    // Returns vector 3 that determines how far the gun recoils
    public Vector3 GetSpread(float shootTime) {
        Vector3 spread = recoilBehaviour.GenerateSpreadAtPoint(shootTime);
        return spread;
    }
}