using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hitFinishLine : MonoBehaviour
{
    public GameObject gameOverUI;
    private bool FinishPlane = false;

    void Start () 
    {
        FinishPlane = false;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {      
        if(collider.tag == "Player")
        {
            soundManager.PlaySound("gameOver");
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            FinishPlane = true;
        }
    }
}
