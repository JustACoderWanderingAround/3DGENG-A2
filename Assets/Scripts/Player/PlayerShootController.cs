using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShootController : MonoBehaviour
{
    // Events invoked when player shoots
    private System.Action<int, int, Vector3> onShootEvents;
    public System.Action<int, int, Vector3> OnShootEvents
    {
        get { return onShootEvents;  }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Subscribe (System.Action<int, int, Vector3> onShootEvent)
    {
        onShootEvents += onShootEvent;
    }
}
