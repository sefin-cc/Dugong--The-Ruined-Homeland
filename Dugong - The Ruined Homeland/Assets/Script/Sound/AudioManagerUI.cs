using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;  

public class AudioManagerUI : MonoBehaviour
{
    public Sound[] uiSounds;
    public static AudioManagerUI instance;
    float volumeValue;

    //Play a cross all scenes
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
       
          foreach (Sound ui in uiSounds)
        {
           ui.source =  gameObject.AddComponent<AudioSource>();
           ui.source.clip = ui.clip;
           ui.source.volume = ui.volume;
           ui.source.loop = ui.loop;
        }
    }

    public void uiPlay (string name)
    {
       Sound ui = Array.Find(uiSounds, sound => sound.name == name);
       if(ui == null){
            Debug.Log("ERROR: cannot find sound");
            return;
       }
       ui.source.Play();
       ui.source.ignoreListenerPause = true;
    }

    //Called in AudioManager
    public void changeVolumeUIsounds(float value)
    { 
        volumeValue = value;
        try{
            foreach (Sound ui in uiSounds)
            {
                ui.source.volume = volumeValue;
            } 
        }catch(Exception e){

        }
       
    }  
}