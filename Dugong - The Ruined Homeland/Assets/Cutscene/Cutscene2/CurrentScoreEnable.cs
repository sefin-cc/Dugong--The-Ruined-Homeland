using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScoreEnable : MonoBehaviour
{
    public TMP_Text currentScore;

    void OnEnable()
    {
        currentScore.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
