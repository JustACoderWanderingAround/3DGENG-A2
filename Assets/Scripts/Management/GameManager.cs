using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public UIManager ui;
    public EffectsManager effects;
    public PlayerShootController controller;
    public CameraManager camManager;


    // Start is called before the first frame update
    void Start()
    {

        controller.SubscribeToShootEvent(audioManager.PlayShootSound);
        controller.SubscribeToShootEvent(ui.UpdateUI);
        controller.SubscribeToShootEvent(effects.SpawnShootEffect);
        controller.SubscribeToShootEvent(camManager.OneShake);

        controller.SubscribeToReloadEvent(ui.UpdateUI);

        controller.SubscribeToWeaponSwapEvent(ui.UpdateUI);
    }
}
