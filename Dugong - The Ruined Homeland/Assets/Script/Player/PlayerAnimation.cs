using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject levelClearedPanel;

   

    void FixedUpdate(){
        transform.Translate(Vector2.right * 5 * Time.deltaTime);
        StartCoroutine(distance());
    }
  

    IEnumerator distance(){
        yield return new WaitForSeconds(4);
        showLevelCleared();
    }

    void showLevelCleared(){
        levelClearedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
