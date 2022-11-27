using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BubbleAttack ProjectilePrefab;
    public Transform attackPoint;
    public Animator anim;
  
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    bool pressedAttack = false;

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
    
    public void spawnBasicAttack(){
        Instantiate(ProjectilePrefab, attackPoint.position, transform.rotation ); 
    }

    //Onclick Basic Attack
    public void basicAttack(){
        
        pressedAttack = true;
    }
}
