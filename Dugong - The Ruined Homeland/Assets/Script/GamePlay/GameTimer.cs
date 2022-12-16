using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text   countdownDisplay;
    public GameObject seaCreature;


    // Start is called before the first frame update
    void Start()
    {
        countdownDisplay.text = "";
        seaCreature.SetActive(false);
        StartCoroutine(gameTimer());
    }


    IEnumerator gameTimer()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
           
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        //Display GameOver or Level Complete Panel
       
        if(FindObjectOfType<BeatScore>().scoreBeaten()){
            FindObjectOfType<GameManager>().levelCleared();
            seaCreature.SetActive(true);
        }else{
            FindObjectOfType<GameManager>().GameOver();
        }
   
    }
}
