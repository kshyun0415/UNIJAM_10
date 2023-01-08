using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    // Sound
    public AudioSource musicSource;
    public AudioSource effectSource1;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Sound
    public void SetMusicVolume(float volume){
        musicSource.volume = volume;
    }
        public void SetEffectVolume(float volume){
        effectSource1.volume = volume;
    }
}
