using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Animator animator;

    public int currentHealth;
    public int maxHealth = 5;
    public int point = 5;

    CircleCollider2D  collider;
    public CircleCollider2D  collider2;
    
    // Start is called before the first frame update
    void Start()
    {
       collider = gameObject.GetComponent<CircleCollider2D>();
       currentHealth = maxHealth; 
    }


     //when player hits the obstacle
    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth> 0){
            //PLAY HIT ANIMATION
            //animator.SetTrigger("damage");
        }else{
            //PLAY DEATH ANIMATION  
            //animator.SetTrigger("dead");
            collider.enabled = false;
            collider2.enabled = false;
            animator.SetTrigger("isDestroy");
        }
    }
    
    public void destroyObstacle(){
        FindObjectOfType<GameManager>().updateScore(point);
        Destroy(gameObject);
    }
}
