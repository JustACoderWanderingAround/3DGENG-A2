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

    bool startCooking = false;
    public override void UseLeftMouseButton()
    {
        CookItem();
        startCooking = true;

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
        if (startCooking)
        {
            if (Input.GetMouseButtonUp(0))
            {
                ThrowItem();
            }
        }
    }

    public override void SetMainItem(IItem newMainItem)
    {
        mainThrowable = (Throwable)newMainItem;
    }
    void CookItem()
    {
        mainThrowable.Use();
    }
    void ThrowItem()
    {

        if (!mainThrowable.GetComponent<Rigidbody>())
        { 
            mainThrowable.gameObject.AddComponent<Rigidbody>();
        }
        if (mainThrowable.gameObject.GetComponent<Collider>())
            mainThrowable.gameObject.GetComponent<Collider>().enabled = true;
        Rigidbody itemRb = mainThrowable.gameObject.GetComponent<Rigidbody>();
        mainThrowable.transform.parent = null;
        itemRb.AddForce(orientation.transform.forward * throwStrength, ForceMode.Impulse);
    }
}
