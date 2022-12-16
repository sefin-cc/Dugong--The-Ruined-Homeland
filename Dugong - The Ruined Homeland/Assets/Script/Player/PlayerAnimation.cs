using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject levelClearedPanel;
    
    public GameObject seaCreature;

    void Start(){
        Physics2D.IgnoreLayerCollision(6,8);
        Physics2D.IgnoreLayerCollision(6,10);
        seaCreature.SetActive(true);

        seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

   

    void FixedUpdate(){
        transform.Translate(Vector2.right * 3 * Time.deltaTime);
        StartCoroutine(distance());
    }
  

    IEnumerator distance(){
        yield return new WaitForSeconds(6);
        Physics2D.IgnoreLayerCollision(6,8, false);
        Physics2D.IgnoreLayerCollision(6,10, false);
         seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        showLevelCleared();
        
    }

    void showLevelCleared(){
        levelClearedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
