using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    int sceneIndex;
    
    //OnClick 
    public void ReplayLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //OnClick 
    public void MainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }
     public void NextLevel(){
       sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;  
       SceneManager.LoadSceneAsync(sceneIndex);   
       Debug.Log("Next Level"); 

    }
}
