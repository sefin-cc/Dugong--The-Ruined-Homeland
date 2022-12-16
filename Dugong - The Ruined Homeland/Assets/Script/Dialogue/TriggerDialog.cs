using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
 public Dialogue dialogue;


    private void OnTriggerEnter2D(Collider2D target){

        if (target.tag =="Player"){   
            Debug.Log("HELLLOOOOo");
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);
            Destroy(gameObject);
        }   
    }
}
