using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObjects : MonoBehaviour
{
    public Transform Obstacle;

    public float speed = 1f;
    public float range = 6;

    float starting;
    int dir =1;

    void Start()
    {
        starting = transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if(transform.position.y < starting || transform.position.y > starting + range){
            dir *= -1;
        }
    }
    
}
