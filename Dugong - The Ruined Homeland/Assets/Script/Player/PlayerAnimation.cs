using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject levelClearedPanel;
    public GameObject seaCreature;
    public GameObject portalEffects;


    public Transform swimPoint;

    bool endSwimming;
    int sceneNumber ;

    void Start(){
        sceneNumber = SceneManager.GetActiveScene().buildIndex ;

        Physics2D.IgnoreLayerCollision(6,8);
        Physics2D.IgnoreLayerCollision(6,10);
     
        StartCoroutine(showCreature());
        seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        portalEffects.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;

        endSwimming = true;
    }

    void FixedUpdate(){
        
        Vector2 swimEnd = new Vector2(13,0);
        float distance = Vector2.Distance(swimEnd, transform.position);
        Debug.Log("Distance: "+ distance);
        if(distance <= 2 && endSwimming){
            endSwimming = false;
            Physics2D.IgnoreLayerCollision(6,8, false);
            Physics2D.IgnoreLayerCollision(6,10, false);
            seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
            portalEffects.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
            
            showLevelCleared();
        }else{
            if((int)swimPoint.position.y  < (int)transform.position.y ){
            transform.Translate(Vector2.down * 2 * Time.deltaTime);
            }else if((int)swimPoint.position.y  > (int)transform.position.y ){
                transform.Translate(Vector2.up * 2 * Time.deltaTime);
            }
            transform.Translate(Vector2.right * 3 * Time.deltaTime);
        }
    }

    IEnumerator distanceStop(){
        yield return new WaitForSeconds(6);
        Physics2D.IgnoreLayerCollision(6,8, false);
        Physics2D.IgnoreLayerCollision(6,10, false);
        seaCreature.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        portalEffects.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        
        showLevelCleared();
        
    }

    IEnumerator showCreature(){
        yield return new WaitForSecondsRealtime(1);
        seaCreature.SetActive(true);
        portalEffects.SetActive(true);
    }

    void showLevelCleared(){
        Debug.Log("Scene: "+ sceneNumber ); 
        if(sceneNumber == 6){
            Time.timeScale = 1f;
            FindObjectOfType<LoadingScreenManager>().startLoadingScreen(7);
        }else{
            FindObjectOfType<AudioManagerUI>().uiPlay("LevelComplete");
            levelClearedPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
