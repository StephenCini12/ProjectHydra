using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip JumpSound, playerDamageSound, CollectSound, selectSound;
    public AudioSource audioSrcMusic;
    public AudioSource audioSrcEffecs;
    private float musicVolume = 0.5f;
    private float effectsVolume = 0.5f;
    void Start()
    {
        //JumpSound = Resources.Load<AudioClip> ("playerJumpSound");
        //playerCollectSound = Resources.Load<AudioClip> ("playerCollect");
        //playerDamageSound = Resources.Load<AudioClip> ("playerDamage");

        // audioSrcMusic = GetComponent<AudioSource>();
        // audioSrcEffecs = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrcMusic.volume = musicVolume;
        audioSrcEffecs.volume = effectsVolume;

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
