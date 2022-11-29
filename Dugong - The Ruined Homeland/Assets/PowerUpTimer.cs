using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PowerUpTimer : MonoBehaviour
{
    public Slider timerContainer; 
    static float seconds = 10;
    static float miliseconds = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
       if(seconds > 0 || miliseconds > 0){
            if(miliseconds <= 0){
                    if(seconds >= 0){
                        seconds--;
                    }
                miliseconds = 100;
            }
        
                miliseconds -= Time.deltaTime * 100; 

                Debug.Log(string.Format("{0}:{1}", seconds, (int)miliseconds));
                if( ( miliseconds >= 25 && miliseconds <= 35 ) || (miliseconds >= 75 && miliseconds <= 85)){
                    timerContainer.value = float.Parse(string.Format("{0}.{1}", seconds, (int)miliseconds));
                }
       }else{
            gameObject.SetActive(false);

       }
    }

    public void setTimer(float sec, float mili){
        seconds = sec;
        miliseconds = mili;
    }
}
