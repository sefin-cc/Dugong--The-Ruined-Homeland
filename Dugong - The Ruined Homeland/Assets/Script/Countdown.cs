using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text   countdownDisplay;

    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(CountdownToStart());
        
    }

    IEnumerator CountdownToStart()
    {
        Time.timeScale = 0f;
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO!";
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
