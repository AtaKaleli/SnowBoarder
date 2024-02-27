using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource sfxAudio;
    [SerializeField] private AudioSource snowboardAudio;
    [SerializeField] private AudioSource backgroundAudio;
    
    [SerializeField] private AudioClip finishSFX;
    [SerializeField] private AudioClip crashSFX;
    [SerializeField] private AudioClip speedUpSFX;
    [SerializeField] private AudioClip collectScoreObjectSFX;
    
    [SerializeField] private AudioClip level1AchivementSFX;
    [SerializeField] private AudioClip level2AchivementSFX;
    [SerializeField] private AudioClip level3AchivementSFX;
    [SerializeField] private AudioClip level4AchivementSFX;

    
    
    void Start()
    {
        instance = this;
        
    }


    public void PlayFinishSFX() => sfxAudio.PlayOneShot(finishSFX); 
    public void PlayCrashSFX() => sfxAudio.PlayOneShot(crashSFX);
    public void PlaySpeedUpSFX() => sfxAudio.PlayOneShot(speedUpSFX);
    public void PlayCollectScoreObjectSFX() => sfxAudio.PlayOneShot(collectScoreObjectSFX);
    
    public void PlayLevel1AchivementSFX() => sfxAudio.PlayOneShot(level1AchivementSFX);
    public void PlayLevel2AchivementSFX() => sfxAudio.PlayOneShot(level2AchivementSFX);
    public void PlayLevel3AchivementSFX() => sfxAudio.PlayOneShot(level3AchivementSFX);
    public void PlayLevel4AchivementSFX() => sfxAudio.PlayOneShot(level4AchivementSFX);

    public void PauseSnowBoardAudio() => snowboardAudio.Pause();
    public void PlaySnowBoardAudio() => snowboardAudio.UnPause();

   



}
