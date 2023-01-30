using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreChecker : MonoBehaviour
{
    static int playerScore;

    void Update(){
         
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if(highscores.highscoreEntryList != null){
        //Set new highscore for Dugong if the current score is higher than the prev highscore
            if( playerScore > highscores.highscoreEntryList[0].score){
                Debug.Log("New HighScore ");
                updatePlayerScore(playerScore, "DUGONG");
               
                PlayerPrefs.SetInt("DugongHighScore", (int)playerScore);
                PlayerPrefs.Save();
            }
        }
    }

    public static void GetPlayerScore(int score){
        playerScore = score;
    }

    private void updatePlayerScore(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntryList[0] = highscoreEntry ;  


        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();    
        Debug.Log(  PlayerPrefs.GetString("highscoreTable") );
       
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }
}
