using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doubler : MonoBehaviour
{
    public Animator animator;
    public TMP_Text powerUpText;
    
    // public GameObject background;
    // public GameObject middleground;
    // public GameObject foreground;
    // public GameObject ground;


    public void DoublerBuffEffect(){
        powerUpText.text = "DOUBLER!";
        FindObjectOfType<PowerUpAnimation>().callPowerUpAnimation();
   
        StartCoroutine(DoublerEffect());
    }
   

    IEnumerator DoublerEffect(){
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isDoubler", true);
        addBonusScore();
        StartCoroutine(ignoreCollision());
        yield return new WaitForSeconds(10);
       
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
        Debug.Log("ENDDNDNDNDN");
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(6,8, false);
      
    }
}
