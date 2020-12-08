using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;
    public static SoundController Singelton { get; private set; }

    private void Awake()
    {
        Singelton = this;
    }

    public void ChangeVolume(float volume)
    {
        for (int i = 0; i < _audioSources.Count; i++)
        {
            _audioSources[i].volume = volume;
        }
    }
}
