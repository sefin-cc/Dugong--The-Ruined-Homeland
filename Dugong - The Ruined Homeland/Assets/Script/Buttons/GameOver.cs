using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    int sceneIndex;
    
    //OnClick 
    public void ReplayLevel(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //OnClick 
    public void MainMenu(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(0);

    }
     public void NextLevel(){
       FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
       sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;  
       FindObjectOfType<LoadingScreenManager>().startLoadingScreen(sceneIndex);
       Debug.Log("Next Level"); 

    }
}
