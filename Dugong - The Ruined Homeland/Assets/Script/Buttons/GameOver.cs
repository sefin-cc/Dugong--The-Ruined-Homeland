using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
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
}
