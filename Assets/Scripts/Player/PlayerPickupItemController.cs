using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItemController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHand;
    bool pickup;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerHand.transform.childCount; ++i)
        {
            if (playerHand.transform.GetChild(i).GetComponent<Rigidbody>())
                playerHand.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            if (playerHand.transform.GetChild(i).GetComponent<Collider>())
                playerHand.transform.GetChild(i).GetComponent<Collider>().enabled = false;
        }
        pickup = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropCurrentItem();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            pickup = true;
        }
        else
        {
            pickup = false;
        }
    }
    private void FixedUpdate()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1.5f);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Item"))
            {
                Debug.Log($"{collider.gameObject.name} is nearby");
                if (pickup)
                {
                    PickItemUp(collider.gameObject);
                    pickup = false;
                }
            }
        }
    }
    void DropCurrentItem()
    {
        Transform objectToDrop = playerHand.transform.GetChild(0);
        objectToDrop.transform.parent = null;
        if (objectToDrop.GetComponent<Rigidbody>())
            objectToDrop.GetComponent<Rigidbody>().isKinematic = true;
        if (objectToDrop.GetComponent<Collider>())
            objectToDrop.GetComponent<Collider>().enabled = true;
    }
    void PickItemUp(GameObject itemToPick)
    {
        Debug.Log("Picking up " + itemToPick.name);
        itemToPick.transform.position = Vector3.zero;
        itemToPick.transform.rotation = Quaternion.identity;
        //if (itemToPick.GetComponent<Rigidbody>())
        //    itemToPick.GetComponent<Rigidbody>().isKinematic = false;
        // set transform to player's hand
        itemToPick.transform.parent = playerHand.transform;
        

    }
}
