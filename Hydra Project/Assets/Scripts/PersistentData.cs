using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData data;
    public float musicVolumeData = 0.5f;
    public float effectsVolumeData = 0.5f;

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
    }

    
}
