using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poopObstacle : MonoBehaviour
{
    private float rangeStop;
    public float minRange;
    public float maxRange;

    public float speed;

    public Transform Obstacle;

    void Start(){
        rangeStop = Random.Range(minRange, maxRange);
    }

    void Update()
    {
        if (transform.position.y < rangeStop) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
