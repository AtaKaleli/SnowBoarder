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

    
    [SerializeField] private AudioClip welcomingInfoSFX;
    [SerializeField] private AudioClip leftShiftInfoSFX;
    [SerializeField] private AudioClip rotateInfoSFX;
    [SerializeField] private AudioClip rotateInfoForwardSFX;
    [SerializeField] private AudioClip trySpinInfoSFX;
    [SerializeField] private AudioClip finalInfoSFX;



    void Start()
    {
        instance = this;
        
    }


    public void PlayWelcomingSFX() => sfxAudio.PlayOneShot(welcomingInfoSFX);
    public void PlayLeftShiftInfoSFX() => sfxAudio.PlayOneShot(leftShiftInfoSFX);
    public void PlayRotateInfoSFX() => sfxAudio.PlayOneShot(rotateInfoSFX);
    public void PlayRotateInfoForwardSFX() => sfxAudio.PlayOneShot(rotateInfoForwardSFX);
    public void PlayTrySpinInfoSFX() => sfxAudio.PlayOneShot(trySpinInfoSFX);
    public void PlayFinalInfoSFX() => sfxAudio.PlayOneShot(finalInfoSFX);








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
