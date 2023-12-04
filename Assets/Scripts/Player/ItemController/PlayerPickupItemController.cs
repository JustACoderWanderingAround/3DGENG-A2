using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandController))]
public class PlayerPickupItemController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHand;
    [SerializeField]
    private ItemCanvasController itemController;
    bool pickup;
    [SerializeField]
    private LayerMask itemLayermask;
    private PlayerHandController handController;
    // Start is called before the first frame update
    void Start()
    {
        handController = GetComponent<PlayerHandController>();
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f, itemLayermask);
        UpdateItemPickUpList(colliders);
        foreach (var collider in colliders)
        {

            Debug.Log($"{collider.gameObject.name} is nearby");


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
                handController.SwapItem(-1);
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
        if (itemToPick.gameObject.GetComponent<Collider>())
            itemToPick.gameObject.GetComponent<Collider>().enabled = false;
        // set transform to player's hand
        itemToPick.transform.parent = playerHand.transform;
        itemToPick.transform.localPosition = Vector3.zero;
        itemToPick.transform.localRotation = Quaternion.identity;
        if (playerHand.transform.childCount > 0)
        {
            itemToPick.SetActive(false);
        }
        handController.SwapItem(0);
    }
    void UpdateItemPickUpList(Collider[] colliders)
    {
        
        //itemController.itemRowList.Clear();
        foreach (Collider collider in colliders)
        {
            foreach (GameObject item in itemController.itemRowList)
            {
               if (item == collider.gameObject)
                {
                    return;
                }
            }
            itemController.AddRow(collider);
        }
    }
}
