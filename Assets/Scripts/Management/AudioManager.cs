using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour//, IShootObserver
{

    [SerializeField] private AudioClip shootAudio;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootAudio;
        audioSource.loop = false;
    }

    public void PlayShootSound(Weapon mainWeapon)
    {
        // TODO: Play respective audio clip
        Debug.Log("Sound played");
        audioSource.Play();
    }
    public void PlayReloadSound(Weapon mainWeapon)
    {

    }
}
