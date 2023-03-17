using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cutscene2Manager : MonoBehaviour
{
    public GameObject skipBtn;
    public GameObject LevelCompletePanel;

    public GameObject introduction;
    public GameObject VideoPlayer;

    public TMP_Text LevelCompleteScore;
    public TMP_Text ShareScore;
   
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
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");

        Destroy(introduction);
        Destroy(VideoPlayer);

        skipBtn.SetActive(false);

        StartCoroutine(showLevelCompletePanel());
    }

    public void endVideo(){
        Destroy(VideoPlayer);
        skipBtn.SetActive(false);

        StartCoroutine(showLevelCompletePanel());
    }

    IEnumerator showLevelCompletePanel()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManagerUI>().uiPlay("LevelComplete");
        LevelCompletePanel.SetActive(true);
    }

}
