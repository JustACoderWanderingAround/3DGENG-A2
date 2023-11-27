using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField] 
    private PlayerShootController shootController;
    [SerializeField]
    private GameObject hand;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (hand.transform.childCount > 0)
        {
            for (int i = 0; i < hand.transform.childCount; ++i)
            {
                hand.transform.GetChild(i).gameObject.SetActive(false);
            }
            //mainWeapon = hand.transform.GetChild(0).GetComponent<Weapon>();
            shootController.SetMainWeapon(hand.transform.GetChild(0).GetComponent<Weapon>());
            hand.transform.GetChild(0).gameObject.SetActive(true);
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

                shootController.SwapWeapon(i - 1);
                break; // Stop checking for keys once one is pressed
            }
        }
    }
    void SwapItem(int index)
    {
        GameObject newMainItem = hand.transform.GetChild(index).gameObject;
        if (newMainItem.GetComponent<Weapon>() != null)
        {
            shootController.SetMainWeapon(newMainItem.GetComponent<Weapon>());

        }
        else if (newMainItem.GetComponent<Throwable>() != null)
        {
            // todo: add throwable controller
        }
    }
}
