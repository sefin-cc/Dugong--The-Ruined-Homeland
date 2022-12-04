using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sonar : MonoBehaviour
{
    public GameObject basicAttackBtn;
    public GameObject sonarAttackBtn;

    public TMP_Text powerUpText;
    public GameObject PowerUpTimer;
    public float duration = 10; 

    void Start(){
        sonarAttackBtn.SetActive(false);
        basicAttackBtn.SetActive(true);
    }
    

    public void sonarAttackEffect(){
       powerUpText.text = "SONAR ATTACK!"; 
       FindObjectOfType<PowerUpAnimation>().callPowerUpAnimation();
       StartCoroutine(sonarEffect());
    }

    IEnumerator sonarEffect(){


        sonarAttackBtn.SetActive(true);
        basicAttackBtn.SetActive(false);
        StartCoroutine(ignoreCollision());
        
        PowerUpTimer.GetComponent<PowerUpTimer>().setTimer(duration,0);
       // PowerUpTimer.SetActive(true);
        yield return new WaitForSeconds(duration);

        sonarAttackBtn.SetActive(false);
        basicAttackBtn.SetActive(true);
      

    }

     IEnumerator ignoreCollision(){
        yield return new WaitForSeconds(2.5f);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(6,8, false);
      
    }
}
