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
        AddBonusScore();
        StartCoroutine(DoublerAnimation());
    }
   

    IEnumerator DoublerAnimation(){
     
        animator.SetBool("isDoubler", true);
       
        yield return new WaitForSeconds(5);
     
        animator.SetBool("isDoubler", false);
    }
    public void AddBonusScore(){
         GameManager.score =  GameManager.score + 20;
    }
}
