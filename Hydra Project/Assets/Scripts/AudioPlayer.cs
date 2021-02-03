using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public GameObject musicSlider;
    public GameObject effectsSlider;
    public AudioClip JumpSound, playerDamageSound, CollectSound, selectSound, NewHighScoreSound;
    public AudioSource audioSrcMusic;
    public AudioSource audioSrcEffecs;
    [SerializeField]
    public float musicVolume = 0.5f;
    [SerializeField]
    public float effectsVolume = 0.5f;
    void Start()
    {
        musicVolume = PersistentData.data.musicVolumeData;
        effectsVolume = PersistentData.data.effectsVolumeData;
        musicSlider.GetComponent<Slider>().value = musicVolume;
        effectsSlider.GetComponent<Slider>().value = effectsVolume;
    }

    void Update()
    {
        // musicVolume = PersistentData.data.musicVolumeData;
        // effectsVolume = PersistentData.data.effectsVolumeData;
        audioSrcMusic.volume = musicVolume;
        audioSrcEffecs.volume = effectsVolume;

        PersistentData.data.musicVolumeData = musicVolume;
        PersistentData.data.effectsVolumeData = effectsVolume;
        PlayerPrefs.SetFloat("MusicAudio", (float)musicVolume);
        PlayerPrefs.SetFloat("EffectAudio", (float)effectsVolume);
    }

    void OnLevelWasLoaded()
    {
        musicSlider.GetComponent<Slider>().value = musicVolume;
        effectsSlider.GetComponent<Slider>().value = effectsVolume;
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

    public void PlayHighScoreSound()
    {
        audioSrcEffecs.PlayOneShot(NewHighScoreSound);
    }
}
