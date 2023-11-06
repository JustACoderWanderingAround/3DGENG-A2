using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public UIManager ui;
    public EffectsManager effects;
    public PlayerShootController controller;


    // Start is called before the first frame update
    void Start()
    {
        // TODO: subscribe the managers to the shoot controller
        controller.Subscribe(audioManager.PlayShootSound);
        controller.Subscribe(ui.UpdateUI);
        controller.Subscribe(effects.SpawnShootEffect);
    }
}
