using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public static MenuAudio instance;

    //[SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioSource SFXSongs;
    [SerializeField] private AudioClip buttonClick;

    private void Awake()
    {
        instance = this;
    }


    public void PlayButtonClick() => SFXSongs.PlayOneShot(buttonClick);
}
