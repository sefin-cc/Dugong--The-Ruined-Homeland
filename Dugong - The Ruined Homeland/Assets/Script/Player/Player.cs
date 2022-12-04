using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

public float tilt = 10f;
public Joystick joystick;
public float speed = 3;

Vector2 movement;

    
private void FixedUpdate(){
    
        movement.y  = joystick.Vertical * speed;
        transform.position += new Vector3(0, movement.y, 0) * Time.deltaTime * 2;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z =  movement.y * tilt;
        transform.eulerAngles = rotation;
}

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } 
    }

}
