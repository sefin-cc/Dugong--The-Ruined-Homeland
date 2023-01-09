using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCreature : MonoBehaviour
{

    private Player Player;
    Animator BonusCreatureAnim;
    public int point;

    void Start(){
       BonusCreatureAnim = gameObject.GetComponent<Animator>();
    }

    //Excutes when the player collides with the GameObject (Weapons)
    private void OnTriggerEnter2D(Collider2D target){
        if (target.tag =="Player"){   
            BonusCreatureAnim.SetTrigger("isHelp");
            FindObjectOfType<AudioManager>().Play("PickUpItem");
            FindObjectOfType<GameManager>().updateScore(point);
        }
    }
}
