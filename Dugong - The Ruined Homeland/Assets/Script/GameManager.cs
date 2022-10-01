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

    public static float score ;

    void Start(){
        score = 0;
        powerUpAnimationText.SetActive(true);
        camera.GetComponent<Animator>().enabled = true;
    }

    public void GameOver()
    {
        camera.GetComponent<Animator>().enabled = false;
        Destroy(powerUpAnimationText);
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        HighscoreTable.GetPlayerScore((int)score);
        score = 0;
        Debug.Log("Game Over: ");
    }

     void Update()
    {
        score += 1 * Time.deltaTime;
        BeatScore.GetPlayerScore((int)score);
        scoreText.text = ((int)score).ToString();
    }

}
