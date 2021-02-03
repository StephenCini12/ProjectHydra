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

    public int SetDefaultSettings = 0;

    public bool GotNewScore = false;
    public bool resetData = false;

    void Start()
    {
        // PlayerPrefs.SetInt("DefaultSettings", (int)0);
        // SetDefaultSettings = PlayerPrefs.GetInt("DefaultSettings");
        // if (SetDefaultSettings == 0)
        // {
        //     PlayerPrefs.SetFloat("MusicAudio", (int) 0.5f);
        //     PlayerPrefs.SetFloat("EffectAudio", (int) 0.5f);
        //     PlayerPrefs.SetInt("DefaultSettings", (int) 1);
        // }
        // Debug.Log(PlayerPrefs.GetInt("DefaultSettings"));
        // musicVolumeData = PlayerPrefs.GetFloat("MusicAudio");
        // effectsVolumeData = PlayerPrefs.GetFloat("EffectAudio");
    }


    void Awake() 
    {
        //PlayerPrefs.SetInt("DefaultSettings", (int)0);
        SetDefaultSettings = PlayerPrefs.GetInt("DefaultSettings");
        if (SetDefaultSettings == 0)
        {
            PlayerPrefs.SetFloat("MusicAudio", (float) 0.5f);
            PlayerPrefs.SetFloat("EffectAudio", (float) 0.5f);
            PlayerPrefs.SetInt("Highscore", (int) 0);
            PlayerPrefs.SetInt("DefaultSettings", (int) 1);
        }
        Debug.Log(PlayerPrefs.GetInt("DefaultSettings"));

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
