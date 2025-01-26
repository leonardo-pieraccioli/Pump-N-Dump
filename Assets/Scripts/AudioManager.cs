using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _pitchedAudioSource;

    void Start()
    {

    }
    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlaySound(AudioClip clip, float pitch)
    {
        if (_pitchedAudioSource.isPlaying)
        {
            _pitchedAudioSource.Stop();
        }

        _pitchedAudioSource.pitch = pitch;
        _pitchedAudioSource.PlayOneShot(clip);
    }
}
