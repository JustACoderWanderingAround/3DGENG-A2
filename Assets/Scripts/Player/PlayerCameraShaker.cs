using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCameraShaker : MonoBehaviour
{
    [SerializeField]
    private List<IShakeBehaviour> shakeBehaviours;


    private Camera camera;
    
    private void OnEnable()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {

        }
    }
}
