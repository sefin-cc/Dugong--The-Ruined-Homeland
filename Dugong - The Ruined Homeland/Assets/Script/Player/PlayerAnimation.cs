using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject levelClearedPanel;
    public GameObject seaCreature;

    public Transform swimPoint;

    void Start(){
        Physics2D.IgnoreLayerCollision(6,8);
        Physics2D.IgnoreLayerCollision(6,10);
        seaCreature.SetActive(true);

        seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

   

    void FixedUpdate(){
        float distance = Vector2.Distance(swimPoint.position, transform.position);

        if((int)swimPoint.position.y  < (int)transform.position.y ){
            transform.Translate(Vector2.down * 2 * Time.deltaTime);
        }else if((int)swimPoint.position.y  > (int)transform.position.y ){
            transform.Translate(Vector2.up * 2 * Time.deltaTime);
        }

        transform.Translate(Vector2.right * 3 * Time.deltaTime);
        StartCoroutine(distanceStop());
    }
  

    IEnumerator distanceStop(){
        yield return new WaitForSeconds(6);
        Physics2D.IgnoreLayerCollision(6,8, false);
        Physics2D.IgnoreLayerCollision(6,10, false);
         seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        showLevelCleared();
        
    }

    void showLevelCleared(){
        FindObjectOfType<AudioManagerUI>().uiPlay("LevelComplete");
        levelClearedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
