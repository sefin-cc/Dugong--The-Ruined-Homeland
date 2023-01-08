using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public bool pauseButton= false;
    public GameObject[] playerUI;
    
    public GameObject dialogPanel;
  
    // Start is called before the first frame update
    void Start()
    {
       pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(pauseButton == true){
            if(isPaused){
                ResumeGame();
                
            }else{
                PauseGame();
                pauseButton = false;
            }
        }
    }

//OnClick Pause and calls the hidePaused( hide the buttons)
    public void PauseButton(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        pauseButton = true;
        dialogPanel.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        hidePaused();
    }
//Sets the Pause Panel Active and pauses the game
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
//Disables the pause panel and continues the game
    public void ResumeGame(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        dialogPanel.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        showUI();
        isPaused = false;
    }

//Onclick go to main menu
    public void GoMainMenu(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        isPaused = false;
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(0);
    }

//Hide player buttons (Joystick, attackbutton, and more)
	public void hidePaused(){
		foreach(GameObject g in playerUI){
			g.SetActive(false);
		}
	}

//Show player buttons
    	public void showUI(){
		foreach(GameObject g in playerUI){
			g.SetActive(true);
		}
	}
}
