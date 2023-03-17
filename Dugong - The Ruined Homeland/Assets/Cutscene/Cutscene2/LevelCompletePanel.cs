using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePanel : MonoBehaviour
{
    void OnEnable()
    {
        FindObjectOfType<Cutscene2Manager>().endVideo();
    }
}
