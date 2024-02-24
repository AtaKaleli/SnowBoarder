using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource sfxAudio;
    [SerializeField] private AudioSource snowboardAudio;
    [SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioSource clappingBackgroundAudio;
    [SerializeField] private AudioClip finishSFX;
    [SerializeField] private AudioClip crashSFX;
    [SerializeField] private AudioClip speedUpSFX;

    
    
    void Start()
    {
        instance = this;
        
    }


    public void PlayFinishSFX() => sfxAudio.PlayOneShot(finishSFX); 
    public void PlayCrashSFX() => sfxAudio.PlayOneShot(crashSFX);
    public void PlaySpeedUpSFX() => sfxAudio.PlayOneShot(speedUpSFX);

    public void PauseSnowBoardAudio() => snowboardAudio.Pause();
    public void PlaySnowBoardAudio() => snowboardAudio.UnPause();

    public void PauseClappingBackgroundAudio() => clappingBackgroundAudio.Pause();
    public void PlayClappingBackgroundAudio() => clappingBackgroundAudio.UnPause();



}
