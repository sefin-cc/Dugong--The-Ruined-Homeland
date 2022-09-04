using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubler : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoublerBuffEffect(){
        Debug.Log("doubler pickup");
        StartCoroutine(DoublerAnimation());
    }
    IEnumerator DoublerAnimation(){
        animator.SetBool("isDoubler", true);
        yield return new WaitForSeconds(5);
        animator.SetBool("isDoubler", false);
    }
}
