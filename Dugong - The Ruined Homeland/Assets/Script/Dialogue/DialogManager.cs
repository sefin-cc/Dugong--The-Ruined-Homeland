using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class DialogManager : MonoBehaviour
{
    public TMP_Text  nameText;
    public TMP_Text  dialogueText;

    public Animator animator;
    float typingSpeed = 0.05f;
  
    private Queue<string> sentences;
    public GameObject background;
    public Joystick joystick;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue){
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        StartCoroutine(waitAnimation());
    }


    public void DisplayNextSentence(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence (sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    IEnumerator waitAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        background.SetActive(true);
        Time.timeScale = 0f;
    }

    void EndDialogue(){
        animator.SetBool("IsOpen", false);
        background.SetActive(false);
        joystick.handleCenter();
 
        Time.timeScale = 1f;
    }
}

