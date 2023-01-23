using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doubler : MonoBehaviour
{
    public Animator animator;
    public TMP_Text powerUpText;
    
    public GameObject PowerUpTimer;
    public float duration = 10; 


    public void DoublerBuffEffect(){
        powerUpText.text = "SCORE X2!";
        FindObjectOfType<PowerUpAnimation>().callPowerUpAnimation();
   
        StartCoroutine(DoublerEffect());
    }
   
    IEnumerator DoublerEffect(){
        
        //Set powerupTimer bar value
        PowerUpTimer.GetComponent<PowerUpTimer>().setTimer(duration,0);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isDoubler", true);
        addBonusScore();
        StartCoroutine(ignoreCollision());

        yield return new WaitForSeconds(0.4f);
        PowerUpTimer.SetActive(true);

        FindObjectOfType<AudioManager>().Play("DoublerInvinsibility");
        yield return new WaitForSeconds(duration);
       
        animator.SetBool("isDoubler", false);
        removeBonusScore();
    }

    public void addBonusScore(){
        FindObjectOfType<GameManager>().doubleScoreAdd(2);
    }

    public void removeBonusScore(){
        FindObjectOfType<GameManager>().doubleScoreAdd(1);
    }

    IEnumerator ignoreCollision(){
        yield return new WaitForSeconds(2.5f);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(6,8, false);
      
    }
}
