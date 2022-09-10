using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
     public GameObject highscorePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Onclick Buttons from menu
    public void GoInGame(){
        SceneManager.LoadScene("InGame");
    }
    public void GoSetting(){
       
    }
    public void backSetting(){
     
    }
    public void GoLeaderboard(){
        highscorePanel.SetActive(true);
    }
     public void backLeaderboard(){
        highscorePanel.SetActive(false);
    }



}
