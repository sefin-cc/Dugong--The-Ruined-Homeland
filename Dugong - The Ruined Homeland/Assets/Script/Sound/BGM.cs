using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public string bgmName;
    void Start()
    {
        FindObjectOfType<AudioManager>().bgmPlay(bgmName);
    }
}