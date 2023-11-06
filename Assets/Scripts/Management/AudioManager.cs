using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour//, IShootObserver
{

    [SerializeField] private AudioClip shootAudio;

    public void PlayShootSound(int unused1, int unused2, Vector3 unused3)
    {
        // TODO: Play respective audio clip
    }
}
