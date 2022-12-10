using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Information 
{
   public Sprite images; 
   public string name;

   [TextArea(3,10)]
   public string sentences;

   public int indentifiers ;

}
