using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;
using Random = UnityEngine.Random;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager instance;
    public GameObject LoadingScreenPanel;
    public float minLoadTime;

    public Image fadeImage;
    public float fadeTime;

    public TMP_Text  informationText;
    public string[] information; 

    int targetSceneInt;
   
    bool isDoneLoad;


    void Awake (){
         if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        LoadingScreenPanel.SetActive(false);
        fadeImage.gameObject.SetActive(false);
    }


    public void startLoadingScreen(int SceneName)
    {
        targetSceneInt = SceneName;
        isDoneLoad = false;
        StartCoroutine(loadLoadingPanel());  
        StartCoroutine(changeInformation()); 
    }


    IEnumerator loadLoadingPanel(){
 
        
        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0);


        while(!fade(1))
            yield return null;

        LoadingScreenPanel.SetActive(true);
        while(!fade(0))
            yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(targetSceneInt);

        float elapsedLoadTime = 0f;
        while(!op.isDone)
        {
            elapsedLoadTime += Time.unscaledDeltaTime;
            yield return null;
        } 
        if(op.isDone){
            isDoneLoad = true;
        }

        while(elapsedLoadTime <  minLoadTime){
            elapsedLoadTime += Time.unscaledDeltaTime;
            yield return null;
        }
  
        while(!fade(1))
            yield return null;

        LoadingScreenPanel.SetActive(false);


        while(!fade(0))
            yield return null;
        
        fadeImage.gameObject.SetActive(false);
    }

    private bool fade(float target){
        fadeImage.CrossFadeAlpha(target, fadeTime, true);
        if(Mathf.Abs(fadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f){
            fadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }
        return false;
    }

    

    IEnumerator changeInformation(){
        while(!isDoneLoad){
            float index = Random.Range(0, information.Length  - 1);
            Debug.Log("index: "+ index);
            informationText.text = information[(int)index];
            yield return new WaitForSecondsRealtime(1.5f);
        }  
    }
}