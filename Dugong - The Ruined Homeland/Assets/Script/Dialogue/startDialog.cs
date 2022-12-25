using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDialog : MonoBehaviour
{
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        Destroy(gameObject);
    }
}
