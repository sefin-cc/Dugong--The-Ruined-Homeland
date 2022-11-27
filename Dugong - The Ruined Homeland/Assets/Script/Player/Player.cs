using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

private Vector3 direction;
public float gravity = -8.8f;
public float strength = 5f;
public float tilt = 4f;
public float topLimit = 1f;



private void Update(){
    // if( Input.GetMouseButtonDown(0) && transform.position.y <=topLimit ){
    //         direction = Vector3.up * strength;
    // }

    // if(Input.touchCount > 0 ){
    //     Touch touch = Input.GetTouch(0);
    //     if(touch.phase == TouchPhase.Began && transform.position.y <= topLimit){
    //         direction = Vector3.up * strength;
    //     }
    // }
}

private void FixedUpdate(){
    
//  // Apply gravity and update the position
//         direction.y += gravity * Time.deltaTime;
//         transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
}

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } 
    }

}
