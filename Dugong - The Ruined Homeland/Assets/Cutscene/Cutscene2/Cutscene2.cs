using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        FindObjectOfType<LoadingScreenManager>().startLoadingScreen(0);
    }
}