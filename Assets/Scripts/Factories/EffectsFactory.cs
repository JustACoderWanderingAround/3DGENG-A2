using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class EffectsFactory : MonoBehaviour
{
    [SerializeField]
    private IEffectProduct product;
    // Start is called before the first frame update

    [SerializeField]
    float maxProductLifeTime = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEffectProduct GetProduct(Vector3 ProductSpawnPos, int Index)
    {
        GameObject instance = Instantiate(product.gameObject, ProductSpawnPos, Quaternion.identity);
        return instance.GetComponent<IEffectProduct>();
    }
}

