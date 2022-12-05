using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    int sceneIndex;

    public void NextLevel(){
        // sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;          

        //   //Only save progress when the saved scene is lower or equal to the current scene
        // if(PlayerPrefs.GetInt("Saved") <= sceneIndex){
        //     PlayerPrefs.SetInt("Saved", sceneIndex);
        //     PlayerPrefs.Save();
        //     Debug.Log(sceneIndex +" Save scene");
        // }

        // SceneManager.LoadSceneAsync(sceneIndex);
    }
}
