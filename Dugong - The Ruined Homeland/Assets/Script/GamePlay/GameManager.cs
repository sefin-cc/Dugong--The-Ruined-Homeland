using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_Text finalScoreText;
    public TMP_Text scoreText;
    public GameObject scoreTextPanel;

    public GameObject playButton;
    public GameObject gameOver;
    public GameObject levelClearedPanel;


    public GameObject powerUpAnimationText;  
    public GameObject camera;
      
    public GameObject Player;
    public Joystick joystick;
    
    public GameObject pauseManager;

    public static float score ;
    public static float doubleScore ;

    int sceneIndex;
    


    void Start(){
        //Reset values
        score = 0;
        doubleScore = 1;
        
        
        powerUpAnimationText.SetActive(true);
        levelClearedPanel.SetActive(false);

        camera.GetComponent<Animator>().enabled = true;
        Player.GetComponent<CapsuleCollider2D>().enabled = true;
        Player.GetComponent<PlayerAnimation>().enabled = false;  
        scoreTextPanel.SetActive(true);
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManagerUI>().uiPlay("GameOver");
        //Disable power up animation
        camera.GetComponent<Animator>().enabled = false;
        Destroy(powerUpAnimationText);

        //Reset and save highscore
        // HighscoreTable.GetPlayerScore((int)score);
        score = 0;
        
        //Hide btns
        pauseManager.GetComponent<PauseManager>().hidePaused(); 

        gameOver.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        
        Debug.Log("Game Over: ");
    }

    public void levelCleared()
    {
        
        //Disable power up animation
        camera.GetComponent<Animator>().enabled = false;
        Destroy(powerUpAnimationText);
        
        //Center Joystick para hindi baswig
        joystick.handleCenter();

        //Hide btns
        pauseManager.GetComponent<PauseManager>().hidePaused(); 
        scoreTextPanel.SetActive(false);

        //Reset, Display and save highscore
        finalScoreText.text = ((int)score).ToString();
        HighScoreChecker.GetPlayerScore((int)score);
        score = 0;
        
       // Player.GetComponent<CapsuleCollider2D>().enabled = false;
        Player.GetComponent<PlayerAnimation>().enabled = true;   

       
        Debug.Log("Level Cleared ");

        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;       

        //Only save progress when the saved scene is lower or equal to the current scene
        if(PlayerPrefs.GetInt("Saved") <= sceneIndex){
            PlayerPrefs.SetInt("Saved", sceneIndex);
            PlayerPrefs.Save();
            Debug.Log(sceneIndex +" Save scene");
        }
    }

     void FixedUpdate()
    {
        BeatScore.GetPlayerScore((int)score);
        scoreText.text = ((int)score).ToString();
    }

    public void doubleScoreAdd(int doubleScoreAdd){
         doubleScore = doubleScoreAdd;
    }

    public void updateScore(int points){
         score += (points * doubleScore);
    }



}
