using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
   public GameObject[] prefab;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;


    void Update (){
        if(Time.time > spawnTime){
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
      float randomX = Random.Range(minX, maxX);
      float randomY = Random.Range(minY, maxY);
      int prefabIndex = Random.Range(0, prefab.Length);
      Instantiate(prefab[prefabIndex], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
