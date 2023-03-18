using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public GameObject skipBtn;
    public GameObject nextScene;

    void Start()
    {
        skipBtn.SetActive(false);
        StartCoroutine(showSkipButton());
    }

    IEnumerator showSkipButton()
    {
        yield return new WaitForSeconds(15f);
        skipBtn.SetActive(true);
        yield return new WaitForSeconds(25f);
        skipBtn.SetActive(false);
    }

    public void skipBtnFunction(){
        FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
        nextScene.SetActive(true);
    }
}