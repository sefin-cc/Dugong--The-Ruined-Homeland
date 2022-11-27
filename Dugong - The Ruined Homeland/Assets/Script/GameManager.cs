using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    public TMP_Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    public GameObject powerUpAnimationText;  
    public GameObject camera;  
    
    public GameObject pauseManager;

    public static float score ;
    public static float doubleScore ;

    void Start(){
        score = 0;
        doubleScore = 1;
        powerUpAnimationText.SetActive(true);
        camera.GetComponent<Animator>().enabled = true;
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
