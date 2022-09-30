using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doubler : MonoBehaviour
{
    public Animator animator;
    public TMP_Text powerUpText;


    public void DoublerBuffEffect(){
        powerUpText.text = "DOUBLER!";
        FindObjectOfType<PowerUpAnimation>().callPowerUpAnimation();
   
        StartCoroutine(DoublerAnimation());
    }
   

    IEnumerator DoublerAnimation(){
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isDoubler", true);
        FindObjectOfType<Parallax>().superSpeedEffect();
        yield return new WaitForSeconds(5);
        FindObjectOfType<Parallax>().superSpeedEffectFinished();
        animator.SetBool("isDoubler", false);
        AddBonusScore();
    }
    public void AddBonusScore(){
         GameManager.score =  GameManager.score + 20;
    }
}
