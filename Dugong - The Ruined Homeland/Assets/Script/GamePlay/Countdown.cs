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

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        pauseManager.GetComponent<PauseManager>().showUI(); 
        AudioListener.pause = false;
        countdownDisplay.gameObject.SetActive(false);
    }
}
