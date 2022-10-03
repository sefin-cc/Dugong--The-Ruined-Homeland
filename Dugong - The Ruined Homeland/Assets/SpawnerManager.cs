using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject hardObstacles;
    public int hardObstaclesScore;

    // Start is called before the first frame update
    void Start()
    {
        hardObstacles.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if(GameManager.score >= hardObstaclesScore ){
            hardObstacles.SetActive(true);
            Destroy(gameObject);
        }
    }
     
}
