using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowableController : IItemTypeController
{
    Throwable mainThrowable;
    [SerializeField]
    public GameObject orientation;
    [SerializeField]
    private float throwStrength = 5.0f;
    public override void UseLeftMouseButton()
    {
        if (Input.GetMouseButtonUp(1))
        {
            ThrowItem();
        }
    }

    public override void UseRightMouseButton()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SetMainItem(IItem newMainItem)
    {

    }
    void ThrowItem()
    {
        Rigidbody itemRb = mainThrowable.gameObject.GetComponent<Rigidbody>();
        mainThrowable.transform.parent = null;
        itemRb.AddForce(orientation.transform.forward * throwStrength, ForceMode.Impulse);
    }
}
