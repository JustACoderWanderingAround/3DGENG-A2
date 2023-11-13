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

    public void PlayShootSound(Weapon mainWeapon, float unused)
    {
        // TODO: Play respective audio clip
        Debug.Log("Sound played");
        if (audioSource.clip != mainWeapon.gunshotAudio)
            audioSource.clip = mainWeapon.gunshotAudio;
        audioSource.Play();
    }
    public void PlayReloadSound(Weapon mainWeapon)
    {

    }
}
