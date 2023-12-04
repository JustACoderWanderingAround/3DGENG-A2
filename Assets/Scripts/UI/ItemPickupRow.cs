using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickupRow : MonoBehaviour
{
    [SerializeField]
    private TMP_Text itemName;
    public void InitItemRow(string itemName)
    {
        this.itemName.text = itemName;
    }
    public void SetColor(int r, int g, int b)
    {
        itemName.color = new Color(r, g, b);
    }
}
