using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip JumpSound;
    //playerDamageSound, playerCollectSound;
    public AudioSource audioSrc;
    private float musicVolume = 1f;
    void Start()
    {
        //JumpSound = Resources.Load<AudioClip> ("playerJumpSound");
        //playerCollectSound = Resources.Load<AudioClip> ("playerCollect");
        //playerDamageSound = Resources.Load<AudioClip> ("playerDamage");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }

    public void PlayJumpSound()
    {
        //audioSrc.clip = JumpSound;
        audioSrc.PlayOneShot(JumpSound);
        //audioSrc.PlayOneShot (JumpSound);
        Debug.Log("Jump Sound play");
    }

    // public void PlayJumpSound (string clip)
    // {
    //     switch (clip)
    //     {
    //         case "playerJumpSound":
    //         audioSrc.PlayOneShot(JumpSound);
    //         break;
    //     }
    
    // Debug.Log("Jump Sound play");

    // }
}
