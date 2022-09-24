using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeatScore : MonoBehaviour
{
     public TMP_Text beatName;
     public TMP_Text beatScore;
     static int playerScore;
   


    // Update is called once per frame
    void FixedUpdate()
    {
       

     
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        Debug.Log(" HighScore: "+ highscores.highscoreEntryList[0].name);

         // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;

                }
            }
        }
        
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
                if (playerScore < highscores.highscoreEntryList[i].score) {
                  beatName.text = highscores.highscoreEntryList[i].name;
                  beatScore.text = highscores.highscoreEntryList[i].score.ToString();
            }
        }

       
    }
 

    public static void GetPlayerScore(int score){
        playerScore = score;
    }
   private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }
      [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }
}