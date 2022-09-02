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
    public int score ; //{ get; private set; }

    // private void Awake()
    // {
    //     Application.targetFrameRate = 60;

    //     player = FindObjectOfType<Player>();
    //     spawner = FindObjectOfType<Spawner>();

    //     Pause();
    // }

    // public void Play()
    // {
    //     score = 0;
    //     scoreText.text = score.ToString();

    //     playButton.SetActive(false);
    //     gameOver.SetActive(false);

    //     Time.timeScale = 1f;
    //     player.enabled = true;

    //     Trash[] trash = FindObjectsOfType<Trash>();

    //     for (int i = 0; i < trash.Length; i++) {
    //         Destroy(trash[i].gameObject);
    //     }
    // }

    public void GameOver()
    {
        // playButton.SetActive(true);
        // gameOver.SetActive(true);

        // Pause();

        Debug.Log("Game Over");
    }

    // public void Pause()
    // {
    //     Time.timeScale = 0f;
    //     player.enabled = false;
    // }

    public void IncreaseScore()
    {
          score++;
          scoreText.text = score.ToString();
    }

}
