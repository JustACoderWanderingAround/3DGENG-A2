using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour//, IShootObserver
{
    [SerializeField] private TMP_Text ammoCounter;
    public void UpdateUI(int currentAmmo, int totalAmmo, Vector3 unused)
    {
        // todo: update UI
        Debug.Log("UI Updated");

    }
}
