using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip ambient_music;
    public int volume;
    void Update()
    {
        audio.volume = volume;
        audio.clip = ambient_music;
        if(audio.isPlaying == false)
            audio.Play();
    }
}
