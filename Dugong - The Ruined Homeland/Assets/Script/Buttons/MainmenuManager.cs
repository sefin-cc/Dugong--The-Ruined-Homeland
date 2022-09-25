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

    //Onclick Buttons from menu
    public void GoInGame(){
        SceneManager.LoadScene("InGame");
    }

    public void GoSetting(){
        settingsPanel.SetActive(true);
    }

    public void backSetting(){
        settingsPanel.SetActive(false);
    }

    public void GoLeaderboard(){
        highscorePanel.SetActive(true);
    }

    public void GoHandBook(){
        handBookPanel.SetActive(true);
    }

    public void backHandBook(){
        handBookPanel.SetActive(false);
    }

    public void backLeaderboard(){
        highscorePanel.SetActive(false);
    }

    public void goresetPanel(){
        resetPanel.SetActive(true);
    }

    public void cancelResetPanel(){
        resetPanel.SetActive(false);
    }


}
