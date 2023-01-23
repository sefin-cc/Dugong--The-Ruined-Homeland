using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
    public Animator powerUpanim;
    public GameObject camera;
    public GameObject pauseManager;

    public Animator playerAnim;
    public Joystick joystick;

    public void callPowerUpAnimation()
    {
        joystick.handleCenter();
        Physics2D.IgnoreLayerCollision(6,8);
        playerAnim.GetComponent<Animator>().SetLayerWeight(1,1);
        pauseManager.GetComponent<PauseManager>().hidePaused(); 
        camera.GetComponent<Animator>().SetTrigger("isPowerUp");
        powerUpanim.SetTrigger("isPowerUp");
    }

    public void playSoundText(){
        FindObjectOfType<AudioManager>().Play("PowerUpText");
    }

    void startAnimPowerUpText ()
    {
        Time.timeScale = 0.2f;
    }
    
    void endAnimPowerUpText ()
    {
       
        Time.timeScale = 1f;
        pauseManager.GetComponent<PauseManager>().showUI(); 
    }
    
}
