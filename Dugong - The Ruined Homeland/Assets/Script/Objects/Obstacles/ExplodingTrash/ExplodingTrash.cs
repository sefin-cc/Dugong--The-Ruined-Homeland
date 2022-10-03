using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTrash : MonoBehaviour
{
    public GameObject exploded;

    // Start is called before the first frame update
    void Start()
    {
        exploded.SetActive(false);
    }


    public void TrashExploded()
    {
        exploded.SetActive(true);
    }
}
