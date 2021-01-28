using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    //public MusicSlider musicSliderScript;
    public GameObject musicSlider;
    public GameObject effectsSlider;
    public AudioClip JumpSound, playerDamageSound, CollectSound, selectSound;
    public AudioSource audioSrcMusic;
    public AudioSource audioSrcEffecs;
    private float musicVolume = 0.5f;
    private float effectsVolume = 0.5f;
    void Start()
    {
        musicVolume = PersistentData.data.musicVolumeData;
        effectsVolume = PersistentData.data.effectsVolumeData;
    }

    void Update()
    {

        audioSrcMusic.volume = musicVolume;
        audioSrcEffecs.volume = effectsVolume;
        PersistentData.data.musicVolumeData = musicVolume;
        PersistentData.data.effectsVolumeData = effectsVolume;
    }

    void OnLevelWasLoaded()
    {
        //musicSlider.GetComponent<Slider>().volume = PersistentData.data.musicVolumeData;
    }


    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }
    public void updateEffectsVolume( float volume)
    {
        effectsVolume = volume;
    }

    public void PlayJumpSound()
    {
        audioSrcEffecs.PlayOneShot(JumpSound);
    }

    public void PlayCollectSound()
    {
        audioSrcEffecs.PlayOneShot(CollectSound);
    }

    public void PlayDamageSound()
    {
        audioSrcEffecs.PlayOneShot(playerDamageSound);
    }

    public void PlaySelectSound()
    {
        audioSrcEffecs.PlayOneShot(selectSound);
    }
}
