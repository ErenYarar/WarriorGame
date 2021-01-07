using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sonrakiLevel : MonoBehaviour
{
    bool getColliderBusy = false;
    public int Respawn;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !getColliderBusy)
        {
            getColliderBusy = true;
            SceneManager.LoadScene(Respawn);
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            getColliderBusy = false;
        }
    }
}
