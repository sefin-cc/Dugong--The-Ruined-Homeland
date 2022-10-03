using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doubler : MonoBehaviour
{
    public Animator animator;
    public TMP_Text powerUpText;
    public GameObject ocean;
    public GameObject seafloor;

    public void DoublerBuffEffect(){
        powerUpText.text = "DOUBLER!";
        FindObjectOfType<PowerUpAnimation>().callPowerUpAnimation();
   
        StartCoroutine(DoublerAnimation());
    }
   

    IEnumerator DoublerAnimation(){
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isDoubler", true);
        ocean.GetComponent<Parallax>().superSpeedEffect();
        seafloor.GetComponent<Parallax>().superSpeedEffect();
        yield return new WaitForSeconds(5);
        ocean.GetComponent<Parallax>().superSpeedEffectFinished();
        seafloor.GetComponent<Parallax>().superSpeedEffectFinished();
        animator.SetBool("isDoubler", false);
        AddBonusScore();
    }
    public void AddBonusScore(){
         GameManager.score =  GameManager.score + 20;
    }
}
