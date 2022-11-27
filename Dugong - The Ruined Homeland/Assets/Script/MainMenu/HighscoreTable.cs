using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    static int playerScore;

    private void Start() {
        entryContainer = transform.Find("highscoreEntryContainer");
 
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

     
        if (highscores == null ) {
            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(0, "DUGONG");
            AddHighscoreEntry(100, "PUGITA");
            AddHighscoreEntry(250, "KABIBE");
            AddHighscoreEntry(450, "MAMENG");
            AddHighscoreEntry(700, "BALYENA");
            AddHighscoreEntry(1000, "PAWIKAN");
            
            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

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

        highscoreEntryTransformList = new List<Transform>();

        
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            Debug.Log(highscores.highscoreEntryList.Count);
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    void Update(){
         
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Set new highscore for Dugong if the current score is higher than the prev highscore
      if( playerScore > highscores.highscoreEntryList[0].score){
        Debug.Log("New HighScore ");
        //Update DUGONG score
        updatePlayerScore(playerScore, "DUGONG");
        //FindObjectOfType<BeatScore>().sortHighScores();
      }
    }

    public static void GetPlayerScore(int score){
        playerScore = score;
    }



    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        
        string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;

        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        transformList.Add(entryTransform);
    }

    public void ResetGame(){
        Debug.Log("Pressed");
        playerScore = 0;
        updatePlayerScore(0, "DUGONG");
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    private void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }
     
        // Add new entry to Highscores
       highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();    
        Debug.Log(  PlayerPrefs.GetString("highscoreTable") );
       
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
