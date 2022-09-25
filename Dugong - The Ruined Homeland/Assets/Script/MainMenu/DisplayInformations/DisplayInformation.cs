using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInformation : MonoBehaviour
{
    public Information[] info;
    public TMP_Text  nameText;
    public TMP_Text  sentenceText;
    public Image  image;

    public Button leftButton;
    public Button rightButton;

    int pageCount =0;

    // Start is called before the first frame update
    void Start()
    {
        pageCount = 0;
        displayPage();
    }

    

    public void nextPageRight(){
        if(pageCount < info.Length-1){
            pageCount++;
            leftButton.gameObject.SetActive(true);
            displayPage();
        }
        if(pageCount == info.Length-1)
        {
            rightButton.gameObject.SetActive(false);
        }
    }

    public void nextPageLeft(){
      if(pageCount > 0){
            pageCount--;
            rightButton.gameObject.SetActive(true);
            displayPage();
        }
        if(pageCount == 0)
        {
            leftButton.gameObject.SetActive(false);
        }
    }

    void displayPage(){
        Debug.Log("page count: "+ pageCount);

        nameText.text = info[pageCount].name;
        sentenceText.text = info[pageCount].sentences;

    }


}
