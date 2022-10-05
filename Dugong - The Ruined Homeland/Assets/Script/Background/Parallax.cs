using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{   
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.1f;
    float currentSpeed;
    float superSpeed = 0.5f; 

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
         currentSpeed = animationSpeed; 
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(currentSpeed * Time.deltaTime, 0);
    }

    public void superSpeedEffect(){
        currentSpeed = superSpeed;
    }

    public void superSpeedEffectFinished(){
        currentSpeed = animationSpeed;
    }
}
