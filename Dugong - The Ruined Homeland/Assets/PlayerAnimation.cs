using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject levelClearedPanel;

    public void showLevelCleared(){
        levelClearedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
