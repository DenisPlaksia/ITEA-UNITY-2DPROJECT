using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _weaponShoot;
    [SerializeField] private List<AudioSource> audioSources;
    public static SoundController Singelton { get; private set; }

    private void Awake()
    {
        Singelton = this;
    }

    public void ChangeVolume(float volume)
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].volume = volume;
        }
    }
}
