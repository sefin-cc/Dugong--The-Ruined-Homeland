using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doubler : MonoBehaviour
{
    public Animator animator;
    public TMP_Text powerUpText;
    
    public GameObject background;
    public GameObject middleground;
    public GameObject foreground;
    public GameObject ground;


    public void DoublerBuffEffect(){
        powerUpText.text = "DOUBLER!";
        FindObjectOfType<PowerUpAnimation>().callPowerUpAnimation();
   
        StartCoroutine(DoublerAnimation());
    }
   

    IEnumerator DoublerAnimation(){
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isDoubler", true);
        background.GetComponent<Parallax>().superSpeedEffect();
        middleground.GetComponent<Parallax>().superSpeedEffect();
        foreground.GetComponent<Parallax>().superSpeedEffect();
        ground.GetComponent<Parallax>().superSpeedEffect();
        yield return new WaitForSeconds(5);
        background.GetComponent<Parallax>().superSpeedEffectFinished();
        middleground.GetComponent<Parallax>().superSpeedEffectFinished();
        foreground.GetComponent<Parallax>().superSpeedEffectFinished();
        ground.GetComponent<Parallax>().superSpeedEffectFinished();
        animator.SetBool("isDoubler", false);
        AddBonusScore();
    }
    public void AddBonusScore(){
         GameManager.score =  GameManager.score + 20;
    }
}
