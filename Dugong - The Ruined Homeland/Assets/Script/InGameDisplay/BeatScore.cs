using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeatScore : MonoBehaviour
{
    public Animator anim;
    public TMP_Text beatName;
    public TMP_Text beatScore;

    public int goalBeatScore;
    public string currentBeatName;

    static int playerScore;
    static bool beat;
   
    void Start(){
        // sortHighScores();
        // beatName.text = currentBeatName;
        // beatScore.text = currentBeatScore.ToString();
        beatName.text = currentBeatName;
        beat = false;
        beatScore.text = goalBeatScore.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            // if (playerScore > currentBeatScore && countPlayer >= 0) {
            //     countPlayer--;
            //     sortHighScores();
            //     beatName.text = currentBeatName;
            //     beatScore.text = currentBeatScore.ToString();
             
            // }
            if (playerScore > goalBeatScore) {
                anim.SetTrigger("hideBeatScore");
                beat = true;
            }
    }
 
    public bool scoreBeaten(){
        return beat;
    }
    // public void sortHighScores(){
          
    //     string jsonString = PlayerPrefs.GetString("highscoreTable");
    //     Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
       

    //      // Sort entry list by Score
    //     for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
    //         for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
    //             if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
    //                 // Swap
    //                 HighscoreEntry tmp = highscores.highscoreEntryList[i];
    //                 highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
    //                 highscores.highscoreEntryList[j] = tmp;

    //             }
    //         }
    //     }
    //     currentBeatScore = highscores.highscoreEntryList[countPlayer].score;
    //     currentBeatName =  highscores.highscoreEntryList[countPlayer].name;
    //     Debug.Log(" currentBeatName: "+ currentBeatName);
       
    // }

    public static void GetPlayerScore(int score){
        playerScore = score;
    }

    // private class Highscores {
    //     public List<HighscoreEntry> highscoreEntryList;
    // }

    // [System.Serializable] 
    // private class HighscoreEntry {
    //     public int score;
    //     public string name;
    // }
}