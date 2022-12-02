using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject levelClearedPanel;


    public GameObject powerUpAnimationText;  
    public GameObject camera;
      
    public Animator playerAnim;
    public GameObject Player;
    
    public GameObject pauseManager;

    public static float score ;
    public static float doubleScore ;

    void Start(){
        score = 0;
        doubleScore = 1;
        powerUpAnimationText.SetActive(true);
        levelClearedPanel.SetActive(false);
        camera.GetComponent<Animator>().enabled = true;
        Player.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    public void GameOver()
    {
        camera.GetComponent<Animator>().enabled = false;
        Destroy(powerUpAnimationText);

        //Hide btns
        pauseManager.GetComponent<PauseManager>().hidePaused(); 

        gameOver.SetActive(true);
        Time.timeScale = 0f;
        HighscoreTable.GetPlayerScore((int)score);
        score = 0;
        Debug.Log("Game Over: ");
    }
    
       public void levelCleared()
    {
        camera.GetComponent<Animator>().enabled = false;
        Destroy(powerUpAnimationText);

        //Hide btns
        pauseManager.GetComponent<PauseManager>().hidePaused(); 
        
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
        playerAnim.SetTrigger("isComplete");
        
        HighscoreTable.GetPlayerScore((int)score);
        score = 0;
        Debug.Log("Level Cleared ");


        // sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;  
        // //Save scene
        // PlayerPrefs.SetInt("Level", sceneIndex);
        // PlayerPrefs.Save();
        // Debug.Log(sceneIndex +" Save scene");
    }



     void FixedUpdate()
    {
        //score += 1 * Time.deltaTime;
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
