using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newScreenDestroy : MonoBehaviour
{
    public Text myText;
    public int Respawn;

    public string[] gameDescriptions = 
    {
        "Press F key for heavy attack",
        "You can throw the stones in your hand with the C key",
        "Kill everyone who attacks you",
        "If you die, you start over!",
        "Watch out for the traps in the ground",
    };
    private IEnumerator Start(){
        string myString = gameDescriptions [Random.Range (0, gameDescriptions.Length)];
        myText.text = myString;
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene(Respawn);
    }  
   
    
}