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

    public static float score ;

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        HighscoreTable.GetPlayerScore((int)score);
        score = 0;
        Debug.Log("Game Over");
    }

     void Update()
    {
        score += 1 * Time.deltaTime;

        scoreText.text = ((int)score).ToString();
    }

}
