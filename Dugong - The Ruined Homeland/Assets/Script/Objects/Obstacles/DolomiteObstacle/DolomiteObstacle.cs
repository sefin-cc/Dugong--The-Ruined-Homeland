using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolomiteObstacle : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 target;

    void Start(){
        target = new Vector3(4.7875f, -0.31f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
