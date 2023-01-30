using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreEnable : MonoBehaviour
{
    public TMP_Text hightScore;

    void OnEnable()
    {
        hightScore.text =  PlayerPrefs.GetInt("DugongHighScore").ToString();
    }
}
