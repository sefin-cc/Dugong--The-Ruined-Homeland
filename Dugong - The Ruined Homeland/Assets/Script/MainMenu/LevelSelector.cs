using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
 public GameObject LevelSelectorPanel;

    public Button lvl1Btn; 
    public Button lvl2Btn; 
    public Button lvl3Btn; 
    public Button lvl4Btn; 


    int savedScene;

    void Start()
    {
        LevelSelectorPanel.SetActive(false);
        savedScene = PlayerPrefs.GetInt("Saved");

        Debug.Log("savedScene: "+ savedScene);

        lvl1Btn.interactable = false;
        lvl2Btn.interactable = false;
        lvl3Btn.interactable = false;
        lvl4Btn.interactable = false;
 
        if(savedScene >= 3){
            lvl1Btn.interactable = true;
        }
        if(savedScene >= 4){
            lvl2Btn.interactable = true;
        }

        if(savedScene >= 5){
            lvl3Btn.interactable = true;
        }

        if(savedScene >= 6){
            lvl4Btn.interactable = true;
        }
    }

    public void levelSelectorOpen(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        LevelSelectorPanel.SetActive(true);

    }
    
    public void levelSelectorClosed(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        LevelSelectorPanel.SetActive(false);
    }

    
    public void tutorialLevel(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(1);
       

    }

    public void levelOne(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(3);


    }
    
    public void levelTwo(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(4);
   
    }

    public void levelThree(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(5);
 
    } 
    public void levelFour(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(6);
      
    }
}
