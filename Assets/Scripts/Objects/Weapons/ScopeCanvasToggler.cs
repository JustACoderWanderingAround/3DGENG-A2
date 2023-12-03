using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScopeCanvasToggler : MonoBehaviour
{
    [SerializeField]
    private GameObject scopeCanvas;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Collider>().enabled == false)
            scopeCanvas.SetActive(Input.GetAxisRaw("Fire2") > 0);
    }
}
