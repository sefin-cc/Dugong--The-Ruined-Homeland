using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;  

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] bgm;

    [SerializeField] Slider volumeSliderSounds; 
    [SerializeField] Slider volumeSliderBgm; 

    void Awake()
    {
        foreach (Sound s in sounds)
        {
           s.source =  gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.loop = s.loop;
        }
          foreach (Sound b in bgm)
        {
           b.source =  gameObject.AddComponent<AudioSource>();
           b.source.clip = b.clip;
           b.source.volume = b.volume;
           b.source.loop = b.loop;
        }
        
    }

    void Start()
    {
        //Sets default value for sound volume if the key doesn't exist
        if(!PlayerPrefs.HasKey("soundsVolume"))
        {
            PlayerPrefs.SetFloat("soundsVolume", 2);
            LoadSound();
        }
        else{
            LoadSound();
        }

        //Sets default value for bgm volume if the key doesn't exist
        if(!PlayerPrefs.HasKey("bgmVolume"))
        {
            PlayerPrefs.SetFloat("bgmVolume", 2);
            LoadBGM();
        }
        else{
            LoadBGM();
        }
    }

    //Play the sounds if it exist
    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null){
            Debug.Log("ERROR: cannot find sound");
            return;
       }
       s.source.Play();
    }

    public void bgmPlay (string name)
    {
       Sound b = Array.Find(bgm, sound => sound.name == name);
       if(b == null){
            Debug.Log("ERROR: cannot find sound");
            return;
       }
      
       b.source.Play();
       Debug.Log("I am called "+ b.source.clip +" AUDIO is playing? "+ b.source.isPlaying);
    }
  
    
    public void pauseAllSoundBGM ()
     {
        foreach (Sound s in sounds)
        {
            s.source.Pause();
        } 
        foreach (Sound b in bgm)
        {
            b.source.Pause();
        }
    }
    

    // Music Panel
    //Onchange Slider
    public void changeVolumesounds()
    { 
        foreach (Sound s in sounds)
        {
           s.source.volume = volumeSliderSounds.value;
        } 
        SaveSound();
    }
    //Onchange Slider
    public void changeVolumeBGM()
    { 
        foreach (Sound b in bgm)
        {
           b.source.volume = volumeSliderBgm.value; 
        }
        SaveBGM();
    }

    //Load and Save the value of the volume
    private void LoadSound()
    {
        volumeSliderSounds.value = PlayerPrefs.GetFloat("soundsVolume");
    }

    private void SaveSound()
    {
        PlayerPrefs.SetFloat("soundsVolume", volumeSliderSounds.value);
    }

    private void LoadBGM()
    {
        volumeSliderBgm.value = PlayerPrefs.GetFloat("bgmVolume");
    }

    private void SaveBGM()
    {
        PlayerPrefs.SetFloat("bgmVolume", volumeSliderBgm.value);
    }
}