using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialog
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

}
