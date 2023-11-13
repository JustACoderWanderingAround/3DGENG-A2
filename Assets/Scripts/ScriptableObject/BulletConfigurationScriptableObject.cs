using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Config", menuName = "Guns/Bullet Config", order = 3)]
public class BulletConfigurationScriptableObject : ScriptableObject
{
    [SerializeField]
    private float bulletVelocity;
    public float BulletVelocity
    {
        get { return bulletVelocity; }
    }
    [SerializeField]
    private float recoilMultipler;
    public float RecoilMultiplier
    {
        get { return recoilMultipler; }
    }


}
