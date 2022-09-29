using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void openSettingsPanel(){
        settingsPanel.SetActive(true);
    }

    public void closeSettingsPanel(){
        settingsPanel.SetActive(false);
    }
}
