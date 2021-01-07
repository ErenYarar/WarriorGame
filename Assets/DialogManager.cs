using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : MonoBehaviour
{
    //public Text nameText;
    public Text dialogText; 
    private Queue<string> sentences;
    public Animator animator;
    public GameObject engel;
    public GameObject quastionMark;
    private void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        //nameText.text = dialog.name;
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        //dialogText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }
    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        engel.SetActive(false);
        Destroy(quastionMark);
    }
}
