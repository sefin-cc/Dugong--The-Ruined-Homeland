using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeObstacleSmoke : MonoBehaviour
{
    public  void poopObstacle(){
        FindObjectOfType<PipeObstacle>().releasePoopObstacle();
    }

    public  void destroySmokeObject(){
      Destroy(gameObject);
    }
}
