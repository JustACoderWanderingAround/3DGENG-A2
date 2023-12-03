using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowableController : IItemTypeController
{
    Throwable mainThrowable;
    [SerializeField]
    public GameObject orientation;
    [SerializeField]
    private float defaultStrength = 5.0f;
    private float throwStrength;

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
        throwStrength = defaultStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCooking)
        {
            throwStrength += Time.deltaTime * 10f;
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
        if (mainThrowable != null)
            mainThrowable.Use();
    }
    void ThrowItem()
    {
        if (mainThrowable != null)
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
            throwStrength = defaultStrength;
        }
    }

    public override IItem GetMainItem()
    {
        return mainThrowable;
    }
}
