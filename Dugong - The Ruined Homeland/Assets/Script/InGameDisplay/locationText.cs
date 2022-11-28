using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class locationText : MonoBehaviour
{

    public TMP_Text  locText;
    public Animator animator;
    public float typingSpeed = 0.1f;
    // List<Location> location;

    public string currentLocation;
    // static int currentStartScore;
    // static int currentEndScore;
    
    // public static int level;

    // Start is called before the first frame update
    void Start()
    {
        // level = 1;
       	// location = new List<Location>() { 
        //         new Location(){ location = "Dead Island", startScore = -5, endScore = -1 },
        //         new Location(){ location = "Freedom Island", startScore = 5, endScore = 110 }
        //         // new Location(){ location = "Lingayen Gulf", startScore = 110, endScore = 260 }
        //     };
        StartDisplay();
    }

    // void FixedUpdate()
    // {
    //     currentLocation = location[level].location;
    //     currentStartScore = location[level].startScore;
    //     currentEndScore = location[level].endScore;

    //     Debug.Log("location: "+ location.Count);

    //     Debug.Log("currentLocation: "+currentLocation+" currentStartScore: "+currentStartScore+" currentEndScore: "+currentEndScore);
    //     Debug.Log("Level: "+ level);

    //     //Check if the player score passes the designated score  
    //     if(GameManager.score >= currentStartScore && GameManager.score < currentEndScore ){
    //         StartDisplay();
    //     }
    // }


    public void StartDisplay (){
        animator.SetBool("isOpen", true);
    }

    //This called in an animation event    
    public void DisplayNextSentence(){
        StartCoroutine(TypeSentence (currentLocation));
        StartCoroutine(waitAnimation());
    }

    //Display text one by one
    IEnumerator TypeSentence (string sentence)
    {
        locText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            locText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
         EndDialogue();
    }

    IEnumerator waitAnimation()
    {
        yield return new WaitForSeconds(0.4f);
    }

    void EndDialogue()
    {
        // if(level<location.Count-1){
        //     level++;
        // }else{
        //     level = 0;
        // }
        animator.SetBool("isOpen", false);
    }
}


// public class Location
// { 
// 	public string location { get; set; }
// 	public int startScore { get; set; }
//     public int endScore { get; set; }
// }