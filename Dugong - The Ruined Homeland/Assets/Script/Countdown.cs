using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text   countdownDisplay;
    public Animator anim;
    public GameObject pauseButton;

    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(CountdownToStart());
        pauseButton.SetActive(false);
        countdownDisplay.text = "";
    }

    IEnumerator CountdownToStart()
    {
        yield return new WaitForSecondsRealtime(0.5f);
     
        while(countdownTime > 0)
        {
            anim.SetTrigger("playCountDown");
            countdownDisplay.text = countdownTime.ToString();
           
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }
        anim.SetTrigger("playCountDown");
        countdownDisplay.text = "GO!";
        Time.timeScale = 1f;
        
        yield return new WaitForSecondsRealtime(1f);
        pauseButton.SetActive(true);
        countdownDisplay.gameObject.SetActive(false);
    }
}
