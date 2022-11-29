using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
    public Animator powerUpanim;
    public Animator cameraAnim;
    public GameObject pauseManager;

    public Animator playerAnim;
    public Joystick joystick;




    public void callPowerUpAnimation()
    {
        Physics2D.IgnoreLayerCollision(6,8);
        playerAnim.GetComponent<Animator>().SetLayerWeight(1,1);
        pauseManager.GetComponent<PauseManager>().hidePaused(); 
        cameraAnim.SetTrigger("isPowerUp");
        powerUpanim.SetTrigger("isPowerUp");
    }

    void startAnimPowerUpText ()
    {
        Time.timeScale = 0.2f;
    }
    void endAnimPowerUpText ()
    {
        joystick.handleCenter();
        pauseManager.GetComponent<PauseManager>().showUI(); 
        Time.timeScale = 1f;
    }
    
}
