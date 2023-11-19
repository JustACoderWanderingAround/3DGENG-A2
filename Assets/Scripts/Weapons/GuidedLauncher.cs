using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedLauncher : Weapon
{

    public override string GetClassName()
    {
        return "GuidedLauncher";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Shoot()
    {
        return false;
    }
}
