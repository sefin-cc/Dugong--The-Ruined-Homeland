using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BubbleAttack basicProjectile;
    public SonarAttack sonarProjectile;

    public Transform sonarAttackPoint;
    public Transform attackPoint;

    public Animator anim;
  
    float attackRate = 3f;
    float nextAttackTime = 0f;

    bool pressedAttack = false;
    static bool basicAttack = false;
    static bool sonarAttack = false;

    void FixedUpdate()
    {  
        //Timer to avoid spamming
        if(Time.time >= nextAttackTime){
            if(pressedAttack == true){
              
                anim.SetTrigger("isAttack");
            }
            pressedAttack = false;
            nextAttackTime = Time.time+ 1f/attackRate;
        }
    }
    
    public void spawnAttack(){
        if(basicAttack){
            Instantiate(basicProjectile, attackPoint.position, transform.rotation ); 
        } else if(sonarAttack){
            Instantiate(sonarProjectile, sonarAttackPoint.position, sonarAttackPoint.transform.rotation ); 
        }
       
    }

    //Onclick Basic Attack
    public void onClickBasicAttack(){
        pressedAttack = true;
        basicAttack = true;
        sonarAttack = false;
        attackRate = 3;
    }

    //Onclick Basic Attack
    public void onClicksonarAttack(){
        pressedAttack = true;
        sonarAttack = true;
        basicAttack = false;
        attackRate = 0.4f;
    }
}
