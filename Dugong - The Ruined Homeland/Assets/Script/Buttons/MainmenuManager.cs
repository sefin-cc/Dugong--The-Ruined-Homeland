using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
     public GameObject highscorePanel;
     public GameObject settingsPanel;
     public GameObject resetPanel;
     public GameObject handBookPanel;

    void Start(){
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    //Onclick Buttons from menu
    public void GoSetting(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        settingsPanel.SetActive(true);
    }

    public void backSetting(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        settingsPanel.SetActive(false);
    }

    public void GoLeaderboard(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        highscorePanel.SetActive(true);
    }

    public void GoHandBook(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        handBookPanel.SetActive(true);
    }

    public void backHandBook(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        handBookPanel.SetActive(false);
    }

    public void backLeaderboard(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        highscorePanel.SetActive(false);
    }

    public void goresetPanel(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        resetPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void cancelResetPanel(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        resetPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }


}
