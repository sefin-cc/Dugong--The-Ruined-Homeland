using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel : MonoBehaviour
{
    //Start Dialog Panel
    public GameObject dialogueOne; 
    public GameObject dialogueTwo;
    public GameObject dialogueThree;
    public GameObject dialogueFour;
    public GameObject dialogueFive;
    public GameObject dialogueSix;     

    //inActive buttons / Panels / GameObjects
    public GameObject AttackButton;
    public GameObject JoystickButton;
    public GameObject ObstacleSpawner;
    public GameObject PowerUpSpawner;
    public GameObject BeatScore;

    public GameManager GameManager;

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
    }

    IEnumerator startDialogueTwo()
    {
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
    }

     IEnumerator startDialogueFour()
    {
        BeatScore.SetActive(true);
        ObstacleSpawner.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        dialogueFour.SetActive(true);
        yield return new WaitForSeconds(3f);
        PowerUpSpawner.SetActive(true);
    }
}
