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
    public GameObject pauseManager;

    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(CountdownToStart());
        pauseManager.GetComponent<PauseManager>().hidePaused(); 
        countdownDisplay.text = "";
        AudioListener.pause = true;
    }

    IEnumerator CountdownToStart()
    {
        yield return new WaitForSecondsRealtime(1f);
     
        while(countdownTime > 0)
        {
            anim.SetTrigger("playCountDown");
            countdownDisplay.text = countdownTime.ToString();
            FindObjectOfType<AudioManagerUI>().uiPlay("Countdown123");
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }
        anim.SetTrigger("playCountDown");
        FindObjectOfType<AudioManagerUI>().uiPlay("CountdownGo");
        countdownDisplay.text = "GO!";
        Time.timeScale = 1f;
        
        yield return new WaitForSecondsRealtime(1f);
        AudioListener.pause = false;
        pauseManager.GetComponent<PauseManager>().showUI(); 
        countdownDisplay.gameObject.SetActive(false);
    }
}
