using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
    public Animator powerUpanim;
    public Animator cameraAnim;
    public GameObject pauseButton;



    public void callPowerUpAnimation()
    {
        pauseButton.SetActive(false);
        cameraAnim.SetTrigger("isPowerUp");
        powerUpanim.SetTrigger("isPowerUp");
    }

    void startAnimPowerUpText ()
    {
        Time.timeScale = 0.2f;
    }
    void endAnimPowerUpText ()
    {
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
}
