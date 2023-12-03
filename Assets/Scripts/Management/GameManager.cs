using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public UIManager ui;
    public EffectsManager effects;
    public PlayerShootController shootController;
    public PlayerHandController handController;
    public CameraManager camManager;


    // Start is called before the first frame update
    void Start()
    {

        shootController.SubscribeToShootEvent(audioManager.PlayShootSound);
        shootController.SubscribeToShootEvent(ui.UpdateUI);
        shootController.SubscribeToShootEvent(effects.SpawnShootEffect);
        shootController.SubscribeToShootEvent(camManager.OneShake);
        shootController.SubscribeToReloadEvent(ui.UpdateUI);
        handController.SubscribeToItemSwapEvent(ui.UpdateUI);
    }
}
