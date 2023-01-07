using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle : MonoBehaviour
{
    public GameObject pipeObstaclePoop;
    public Transform pipePoint;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f * Time.deltaTime, 0);
    }

    public  void releasePoopObstacle(){
        Instantiate(pipeObstaclePoop, pipePoint.position, transform.rotation ); 
    }
}
