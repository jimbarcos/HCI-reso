using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("- Audio Source - ")]
    [SerializeField] AudioSource BGMusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("- Public Clip - ")]
    public AudioClip BGMusicClip;
    public AudioClip ClickSource;
    public AudioClip Lvl1Source;
    public AudioClip Lvl2Source;
    public AudioClip Lvl3Source;


    public AudioClip CorrectSource;
    public AudioClip WrongSource;
    public AudioClip CongratsSource;


    private void Start()
    {
        BGMusicSource.clip = BGMusicClip;
        BGMusicSource.Play();
    }

    public void PlayClickSound(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(ClickSource);
    }

    public void PlayCorrectTrash(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(CorrectSource);
    }

    public void PlayWrongTrash(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(WrongSource);
    }

    public void PlayCongrats(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(CongratsSource);
    }


}

