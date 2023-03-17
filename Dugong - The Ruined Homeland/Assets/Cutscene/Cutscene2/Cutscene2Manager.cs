using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Playables;

public class Cutscene2Manager : MonoBehaviour
{
    public GameObject skipBtn;
    public GameObject LevelCompletePanel;
    public TMP_Text LevelCompleteScore;
    public TMP_Text ShareScore;
    public PlayableDirector currentTimeline;
    int sceneIndex;
    
    
    void Start()
    {
        LevelCompleteScore.text = PlayerPrefs.GetInt("Score").ToString();
        ShareScore.text = PlayerPrefs.GetInt("Score").ToString();
        skipBtn.SetActive(false);
        StartCoroutine(showSkipButton());
    }

    IEnumerator showSkipButton()
    {
        yield return new WaitForSeconds(15f);
        skipBtn.SetActive(true);
        yield return new WaitForSeconds(25f);
        skipBtn.SetActive(false);
    }

    //OnClick 
    public void ReplayLevel(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        Time.timeScale = 1f;
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(6);
    }

    //OnClick 
    public void MainMenu(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(0);

    }

    public void skipBtnFunction(){
        FindObjectOfType<AudioManagerUI>().uiPlay("buttonSound");
        currentTimeline.time = currentTimeline.duration; //Go to last frame
        currentTimeline.Pause();
        LevelCompletePanel.SetActive(true);
    }
     
}
