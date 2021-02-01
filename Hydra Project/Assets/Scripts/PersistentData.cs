using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PersistentData : MonoBehaviour
{
    public static PersistentData data;
    [SerializeField]
    public float musicVolumeData;
    [SerializeField]
    public float effectsVolumeData;
    [SerializeField]
    public float Highscore;
    public bool GotNewScore = false;
    public bool On = false;

    void Start()
    {
        //Debug.Log(PlayerPrefs.GetFloat("MusicAudio"));
        // musicVolumeData = PlayerPrefs.GetFloat("MusicAudio");
        // effectsVolumeData = PlayerPrefs.GetFloat("EffectAudio");
    }


    void Awake() 
    {
        if(data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if(data != this)
        {
            Destroy(gameObject);
        }
        Highscore = PlayerPrefs.GetInt("Highscore");
        musicVolumeData = PlayerPrefs.GetFloat("MusicAudio");
        effectsVolumeData = PlayerPrefs.GetFloat("EffectAudio");
    }

    
}
