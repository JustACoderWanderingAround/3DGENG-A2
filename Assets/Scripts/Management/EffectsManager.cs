using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField]
    private List<EffectsFactory> effectsFactories;
    public void SpawnShootEffect(Weapon mainWeapon, float unused)
    {
        
        IEffectProduct newEffect = effectsFactories[0].GetProduct(mainWeapon.barrelTip.transform.position, 0);
        Destroy(newEffect.gameObject, 0.1f);
        
    }
}
