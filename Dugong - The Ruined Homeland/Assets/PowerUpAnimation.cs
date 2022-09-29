using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
    public Animator powerUpanim;
    public GameObject pauseButton;

 
    public void callPowerUpAnimation()
    {
        powerUpanim.SetTrigger("isPowerUp");
    }

    void startAnimPowerUpText ()
    {
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    void endAnimPowerUpText ()
    {
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
}
