using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    // Start is called before the first frame update
   private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>(){
            new HighscoreEntry { score = 1000, name ="SASA"},
            new HighscoreEntry { score = 1320, name ="HUAH"},
            new HighscoreEntry { score = 1310, name ="SASA"},
            new HighscoreEntry { score = 1111, name ="HUAH"},
            new HighscoreEntry { score = 999, name ="SASA"},
            new HighscoreEntry { score = 2323, name ="HUAH"},
        };

        //Sort entry list by Score
        for(int i = 0; i< highscoreEntryList.Count; i++){
            for(int j = i + 1; j < highscoreEntryList.Count; j++){
                if(highscoreEntryList[j].score > highscoreEntryList[i].score){
                //Swap
                HighscoreEntry tmp = highscoreEntryList[i];
                highscoreEntryList[i] = highscoreEntryList[j];
                highscoreEntryList[j] = tmp;
                }
            }
        }


        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

        private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList){
            float templateHeight = 20f;

            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;

            }

            entryTransform.Find("posText").GetComponent<TMP_Text >().text = rankString;

            int score = highscoreEntry.score;
            entryTransform.Find("scoreText").GetComponent<TMP_Text >().text = score.ToString();

            string name = highscoreEntry.name;
            entryTransform.Find("nameText").GetComponent<TMP_Text >().text = name;

            transformList.Add(entryTransform);
        }

        private class HighscoreEntry {
            public int score;
            public string name;
        }

    }

