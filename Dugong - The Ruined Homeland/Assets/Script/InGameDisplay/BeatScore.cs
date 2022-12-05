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
        playerScore = 0;
        beatName.text = currentBeatName;
        beat = false;
        beatScore.text = goalBeatScore.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            if (playerScore > goalBeatScore) {
                anim.SetTrigger("hideBeatScore");
                beat = true;
            }
    }
 
    public bool scoreBeaten(){
        return beat;
    }
 

    public static void GetPlayerScore(int score){
        playerScore = score;
    }

}