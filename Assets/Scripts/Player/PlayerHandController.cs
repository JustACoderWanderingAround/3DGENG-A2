using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    //[SerializeField]
    [SerializeField]
    private List<GameObject> controllerList;
    private IItemTypeController mainController;
    [SerializeField]
    private GameObject hand;
    private Transform defaultTransform;

    
    // Start is called before the first frame update
    private void OnEnable()
    {
        defaultTransform = hand.transform;
        if (hand.transform.childCount > 0)
        {
            for (int i = 0; i < hand.transform.childCount; ++i)
            {
                hand.transform.GetChild(i).gameObject.SetActive(false);
            }
            //mainWeapon = hand.transform.GetChild(0).GetComponent<Weapon>();
            //mainController.SetMainWeapon(hand.transform.GetChild(0).GetComponent<Weapon>());
            hand.transform.GetChild(0).gameObject.SetActive(true);
            mainController = controllerList[0].GetComponent<IItemTypeController>();
            SwapItem(0);
        }
    }

        // Update is called once per frame
    void Update()
    {
        int numberofItems = hand.transform.childCount; // Change this to the number of weapons you have
        for (int i = 1; i <= numberofItems; i++)
        {
            if (Input.GetKey(KeyCode.Alpha0 + i))
            {

                SwapItem(i - 1);
                //mainController.SwapWeapon(i - 1);
                break; // Stop checking for keys once one is pressed
            }
        }
        if(Input.GetMouseButton(0))
        {
            mainController.UseLeftMouseButton();
        }
        if (Input.GetMouseButton(1))
        {
            mainController.UseRightMouseButton();
        }
    }
    void SwapItem(int index)
    {
        
        if (hand.transform.childCount > 1)
        {
            for (int i = 0; i < hand.transform.childCount; ++i)
            {
                hand.transform.GetChild(i).gameObject.SetActive(false);
            }

        }
        GameObject newMainItem = hand.transform.GetChild(index).gameObject;
        newMainItem.SetActive(true);
        if (newMainItem.GetComponent<Weapon>() != null)
        {
            mainController = controllerList[0].GetComponent<PlayerShootController>();
            mainController.SetMainItem(newMainItem.GetComponent<Weapon>());

        }
        else if (newMainItem.GetComponent<Throwable>() != null)
        {
            // todo: add throwable controller
            mainController = controllerList[1].GetComponent<PlayerThrowableController>();
            mainController.SetMainItem(newMainItem.GetComponent<Throwable>());
        }
        hand.transform.position = defaultTransform.position;
        hand.transform.rotation = defaultTransform.rotation;
    }
}
