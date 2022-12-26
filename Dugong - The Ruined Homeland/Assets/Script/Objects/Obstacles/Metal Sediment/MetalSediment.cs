using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSediment : MonoBehaviour
{
    public GameObject smallSediments;

    public void showSmallSediments(){
        smallSediments.SetActive(true);
    }

    public void destroyBigSediment(){
        Destroy(gameObject);
    }
}
