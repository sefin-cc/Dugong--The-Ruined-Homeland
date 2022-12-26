using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialLevel : MonoBehaviour
{
    //Start Dialog Panel
    public GameObject dialogueOne; 
    public GameObject dialogueTwo;
    public GameObject dialogueThree;
    public GameObject dialogueFour;
    public GameObject dialogueFive;
    public GameObject dialogueSix;     

    public GameObject instructionsPanel;
    public TMP_Text  instructionsText;

    //inActive buttons / Panels / GameObjects
    public GameObject AttackButton;
    public GameObject JoystickButton;
    public GameObject ObstacleSpawner;
    public GameObject PowerUpSpawner;
    public GameObject BeatScore;
    public GameObject GameTimer;
    public GameObject DisplayLocation;


    public GameObject ingameObstacleSpawner;

    public GameManager GameManager;
    public GameObject gameManagerGameObject;

    //Joystick stuff
    public Joystick joystick;
    Vector2 movement;



    bool useJoystick = true;
    bool checkScore = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startDialogueOne());
    }

    // Update is called once per frame
    void Update()
    {
        if(useJoystick){
        movement.y  = joystick.Vertical;
            if ( movement.y > 0 || movement.y < 0){
                Debug.Log("Dialog#2");
                StartCoroutine(startDialogueTwo());
                useJoystick = false;
            }
        }

        if(checkScore){
            if(GameManager.score > 0){
                checkScore = false;
                Debug.Log("Dialog#4");
                StartCoroutine(startDialogueFour());
            }
        }
        
    }

    IEnumerator startDialogueOne()
    {
        yield return new WaitForSecondsRealtime(3f);
        dialogueOne.SetActive(true);
        yield return new WaitForSeconds(2f);
        JoystickButton.SetActive(true);
        instructionsText.text = "Move the Joystick";
        instructionsPanel.SetActive(true);
       

    }

    IEnumerator startDialogueTwo()
    {
        instructionsPanel.SetActive(false);
        yield return new WaitForSecondsRealtime(3f);
        dialogueTwo.SetActive(true);
        yield return new WaitForSeconds(2f);
        AttackButton.SetActive(true);
        yield return new WaitForSeconds(5f);
        StartCoroutine(startDialogueThree());
    }

    IEnumerator startDialogueThree()
    {
        dialogueThree.SetActive(true);
        yield return new WaitForSeconds(2f);
        checkScore = true;
        ObstacleSpawner.SetActive(true);
        instructionsText.text = "Aim and shoot at the obstacles! ";
        instructionsPanel.SetActive(true);
    }

     IEnumerator startDialogueFour()
    {
        instructionsPanel.SetActive(false);
        BeatScore.SetActive(true);
        ObstacleSpawner.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        dialogueFour.SetActive(true);
        yield return new WaitForSeconds(3f);
        PowerUpSpawner.SetActive(true);
        instructionsText.text = "Pick Up the power-up! ";
        instructionsPanel.SetActive(true);
    }


    public void callDialogueFive(){
        instructionsPanel.SetActive(false);
        StartCoroutine(startDialogueFive());
    }

    IEnumerator startDialogueFive()
    {
        PowerUpSpawner.SetActive(false);
        yield return new WaitForSecondsRealtime(4f);
        ObstacleSpawner.SetActive(true);
        dialogueFive.SetActive(true);
        yield return new WaitForSeconds(10f);
        StartCoroutine(startDialogueSix());
    }

    
     IEnumerator startDialogueSix()
    {
        ObstacleSpawner.SetActive(false);
        dialogueSix.SetActive(true);
        yield return new WaitForSeconds(3f);
        DisplayLocation.SetActive(true);
        GameTimer.SetActive(true);
        gameManagerGameObject.GetComponent<GameTimer>().enabled = true; 
        ingameObstacleSpawner.SetActive(true);
    }
}
