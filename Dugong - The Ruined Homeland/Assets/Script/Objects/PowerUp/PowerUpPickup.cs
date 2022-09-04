using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
public string objectPickUp ="";
//Excutes when the player collides with the GameObject (Weapons)
private void OnTriggerEnter2D(Collider2D target){
 if (target.tag =="Player"){   
   
    if(objectPickUp == "doubler" ){
        Debug.Log("doubler pickup");
      
    }
       if(objectPickUp == "invul" ){
        Debug.Log("invul pickup");
   
    }
    
   // Removes the weapon on the ground
    Destroy(gameObject);
 }
}
}
