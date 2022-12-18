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

    public Sprite lockedImg;
    public float heightLocked;
    public float widthLocked;

    int pageCount =0;
    int savedScene;

    RectTransform rt;
    

    // Start is called before the first frame update
    void Start()
    {
        rt = image.GetComponent<RectTransform>();
        pageCount = 0;
        displayPage();
    }

    

    public void nextPageRight(){
        if(pageCount < info.Length-1){
            FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
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
            FindObjectOfType<AudioManagerUI>().uiPlay("ButtonPress");
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
        savedScene = PlayerPrefs.GetInt("Saved");
        Debug.Log("page count: "+ pageCount);

        
        rt.sizeDelta = new Vector2(info[pageCount].width, info[pageCount].height);


        image.GetComponent<Image>().sprite = info[pageCount].images;
        nameText.text = info[pageCount].name;
        sentenceText.text = info[pageCount].sentences;

        if(savedScene <= 2){
          //  lvl1
            if(info[pageCount].indentifiers > 1){
                lockedPage();
            }
        } else if(savedScene == 3){
          //  lvl2
            if(info[pageCount].indentifiers > 2){
               lockedPage();
            }
        } else if(savedScene == 4){
          //  lvl3
            if(info[pageCount].indentifiers > 3){
               lockedPage();
            }
        }
    }

    void lockedPage(){
        rt.sizeDelta = new Vector2(widthLocked, heightLocked);
        image.GetComponent<Image>().sprite = lockedImg;
        nameText.text = "???";
        sentenceText.text = "To be Unlocked";
    }


}
