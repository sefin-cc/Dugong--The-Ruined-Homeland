using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickupTutorial : MonoBehaviour
{
    public string objectPickUp ="";
    private Player Player;

     //Excutes when the player collides with the GameObject (Weapons)
    private void OnTriggerEnter2D(Collider2D target){
        if (target.tag =="Player"){   
        
            if(objectPickUp == "invul"  ){
                FindObjectOfType<TutorialLevel>().callDialogueFive();
                Player.FindObjectOfType<Invulnerability>().InvulBuffEffect();
                FindObjectOfType<AudioManager>().Play("PickUpItem");
            }
            // Removes the weapon on the ground
            Destroy(gameObject);
        }
    }
}
