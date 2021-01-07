using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    //public GameObject soruIsareti;
    public void TriggerDialog()
    {
        //soruIsareti.SetActive(true);
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
