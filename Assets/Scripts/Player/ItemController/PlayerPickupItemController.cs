using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandController))]
public class PlayerPickupItemController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHand;
    bool pickup;
    [SerializeField]
    private LayerMask itemLayermask;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerHand.transform.childCount; ++i)
        {
            if (playerHand.transform.GetChild(i).GetComponent<Rigidbody>())
                Destroy(playerHand.transform.GetChild(i).GetComponent<Rigidbody>());
            if (playerHand.transform.GetChild(i).GetComponent<Collider>())
                playerHand.transform.GetChild(i).GetComponent<Collider>().enabled = false;
        }
        pickup = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropCurrentItem();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pickup");
            pickup = true;
        }
        else
        {
            pickup = false;
        }
    }
    private void FixedUpdate()
    {
        var colliders = Physics.OverlapSphere(transform.position, 5f, itemLayermask);
        foreach (var collider in colliders)
        {
            
            Debug.Log($"{collider.gameObject.name} is nearby");
            if (pickup)
            {
                PickItemUp(collider.gameObject);
                pickup = false;
            }
            
        }
    }
    void DropCurrentItem()
    {
        Transform objectToDrop;
        for (int i = 0; i < playerHand.transform.childCount; ++i)
        {
            if (playerHand.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                objectToDrop = playerHand.transform.GetChild(i);
                if (!objectToDrop.GetComponent<Rigidbody>())
                {
                    objectToDrop.gameObject.AddComponent<Rigidbody>();
                }
                if (objectToDrop.gameObject.GetComponent<Collider>())
                    objectToDrop.gameObject.GetComponent<Collider>().enabled = true;
                objectToDrop.transform.parent = null;
                return;
            }
        }
        return;
       
    }
    void PickItemUp(GameObject itemToPick)
    {
        Debug.Log("Picking up " + itemToPick.name);
        if (itemToPick.GetComponent<Rigidbody>())
        {
            Destroy(itemToPick.GetComponent<Rigidbody>());
        }
        // set transform to player's hand
        itemToPick.transform.parent = playerHand.transform;
        itemToPick.transform.localPosition = Vector3.zero;
        itemToPick.transform.localRotation = Quaternion.identity;

    }
}
