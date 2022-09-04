using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
public string objectPickUp ="";
//public GameObject Player;
private Player Player;


//Excutes when the player collides with the GameObject (Weapons)
private void OnTriggerEnter2D(Collider2D target){
 if (target.tag =="Player"){   
   
    if(objectPickUp == "doubler" ){
      
        Player.FindObjectOfType<Doubler>().DoublerBuffEffect();
    }
       if(objectPickUp == "invul" ){
    
        Player.FindObjectOfType<Invulnerability>().InvulBuffEffect();
   
    }
    
   // Removes the weapon on the ground
    Destroy(gameObject);
 }
}
}
